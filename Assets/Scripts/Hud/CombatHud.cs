using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CombatHud : MonoBehaviour
{
    public GameObject monsterObject;
    public RectTransform transition;
    public Slider healthSlider, attackSlider;
    public Image monsterSprite;
    public Text monsterName, health;
    public bool isTransition = true;
    
    public int monsterHealth = 2, monsterMaxHealth, monsterAttackCount;
    public Monster monster;
    void Start()
    {
        Invoke("Enter", 2f);
        AudioManager.Instance.ChangeMusic("Fight");
    }

    public void Initialize(Monster _monster, int attackCount){
        monster = _monster;
        monsterSprite.sprite = monster.monsterSprite;
        monsterSprite.SetNativeSize();
        monsterName.text = monster.monsterName;
        monsterHealth = monster.monsterHealth;
        monsterMaxHealth = monster.monsterHealth;
        monsterAttackCount = attackCount;
        healthSlider.maxValue = monster.monsterHealth;
    }

    private void Update() {
        transition.anchoredPosition = Vector2.Lerp(transition.anchoredPosition, new Vector2(x : isTransition ? 0 : -720f, y : transition.anchoredPosition.y), Time.deltaTime * 3f);

        monsterObject.SetActive(isTransition ? false : true);
        if(!isTransition) health.text = $"{monsterHealth}" + "/" + $"{monsterMaxHealth}";
        healthSlider.value = monsterHealth;

        if(monsterHealth <= 0){
            Leave();
        }

    }

    public void Enter(){
        isTransition = false;
    }

    public void Leave(){
        Destroy(this.gameObject);
        var material = PlayerPrefs.GetInt("Materials") + 1;
        PlayerPrefs.SetInt("Materials", material);
        var gold = PlayerPrefs.GetInt("Gold") + monster.monsterDrop;
        PlayerPrefs.SetInt("Gold", gold);
        PlayerBag.Instance.SaveBag();
        Game.Instance.Hud.SetActive(true);
        AudioManager.Instance.ChangeMusic("Theme");
        Player.Instance.OnKill();
    }

}
