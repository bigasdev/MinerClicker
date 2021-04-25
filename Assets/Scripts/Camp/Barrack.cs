using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrack : MonoBehaviour
{
    public BuildStatus status;
    public BuildType type;
    public int materialQuantity, oreQuantity, goldQuantity;
    
    bool mouseClose;
    public static bool canClick;

    private void Start() {
        canClick = true;
        
        if(PlayerPrefs.HasKey(type.ToString())){
             BuildStatus mStatus = (BuildStatus) System.Enum.Parse(typeof (BuildStatus), PlayerPrefs.GetString(type.ToString()));
             status = mStatus;
        }
        ChangeStatus();
    }
    private void Update() {
        if(StateController.Instance.currentState != StateDefinition.GAME) return;
        
        CheckForMouse();
    }
    public virtual void CheckForMouse(){
        var mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var mousePos = Camera.main.ScreenToWorldPoint(mouse);
        mouseClose = false;

        if(Vector2.Distance(mousePos, transform.position) <= 1f){
            mouseClose = true;
        }

        if(Vector2.Distance(mousePos, transform.position) <= .5f){
            StartCoroutine(StartButton());
            transform.DOScale(new Vector3(1.03f, 1.03f, 1f), .25f);

            if(Input.GetMouseButtonDown(0) && canClick){
                canClick = false;
                if(status == BuildStatus.NOT_BUILT){
                   var tabs = FindObjectOfType<BarrackBuild>();

                   if(tabs != null) Destroy(tabs.gameObject);
                
                   var tab = Resources.Load<BarrackBuild>("Prefabs/Hud/BuildHud");
                   tab.Initialize(materialQuantity, oreQuantity, goldQuantity, this);
                   Instantiate(tab);
                }
                else
                {

                }
            }
        }
        else{
            if(mouseClose == false) return;
            
            transform.DOScale(new Vector3(1f, 1f, 1f), .25f);
            FinishButton();
        }
    }

    IEnumerator StartButton(){
        yield return transform.localScale = new Vector3(1.03f, 1.03f, 1f);
        
        var buttons = FindObjectOfType<BarrackButton>();

        if(buttons != null) yield break;
        
        var button = Resources.Load<BarrackButton>("Prefabs/Hud/BarrackButtons");
        button.Initialize(status == BuildStatus.COMPLETED ? "USE" : "BUILD");
        Instantiate(button, transform.position, Quaternion.identity);
    }

    void FinishButton(){
        var buttons = FindObjectOfType<BarrackButton>();

        if(buttons != null) Destroy(buttons.gameObject);
    }

    public virtual void ChangeStatus(){
            if(status == BuildStatus.NOT_BUILT){
               GetComponent<SpriteRenderer>().color = new Color(1,1,1,.5f);
            }
            else{
               GetComponent<SpriteRenderer>().color = new Color(1,1,1, 1f);
            }
    }
    public virtual void Build(){
        status = BuildStatus.COMPLETED;
        ChangeStatus();
        
        PlayerPrefs.SetString(type.ToString(), "COMPLETED");
        PlayerPrefs.Save();
    }

    public virtual void Open(){

    }

    public virtual void Close(){

    }
}
public enum BuildStatus{
    COMPLETED,
    NOT_BUILT
}

public enum BuildType{
    ARMORER,
    UTILITY
}
