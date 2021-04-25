using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    private static Player instance;

    public static Player Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }
    public LayerMask mineralMask;
    
    RaycastHit2D hit;

    bool canMine = true;
    
    public Transform Position{
        get{
            return transform;
        }
    }
    private void Update() {
       hit = Physics2D.Raycast(transform.position, Vector3.down, 1f, mineralMask);

       if(health <= 0){

       }
    }
    public void Mine(){    
        if(hit && StateController.Instance.currentState == StateDefinition.GAME){
            Debug.Log(hit);
            hit.collider.GetComponent<Mineral>().ReduceHealth(1);
        }
    }

    public void OnKill()
    {
        StartCoroutine(Drops());
    }

    IEnumerator Drops()
    {
        yield return new WaitForSeconds(.3f);
        MineralManager.Instance.DropOre("Gold", transform.position);
        yield return new WaitForSeconds(.2f);
        MineralManager.Instance.DropOre("Material", transform.position);
    }
}
