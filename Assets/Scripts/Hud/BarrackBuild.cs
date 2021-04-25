using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrackBuild : MonoBehaviour
{
    public Text materialQuantity, oreQuantity, goldQuantity;
    public int firstQuantity, secondQuantity, thirdQuantity;
    
    public Barrack barrack;
    public void Initialize(int _firstQuantity, int _secondQuantity, int _thirdQuantity, Barrack _barrack)
    {
        firstQuantity = _firstQuantity;
        secondQuantity = _secondQuantity;
        thirdQuantity = _thirdQuantity;
        barrack = _barrack;
    }
    
    private void Update() 
    {
        materialQuantity.text = $"{PlayerBag.Instance.Materials}" + "/" + $"{firstQuantity}";
        oreQuantity.text = $"{PlayerBag.Instance.Ores}" + "/" + $"{secondQuantity}";
        goldQuantity.text = $"{PlayerBag.Instance.Gold}" + "/" + $"{thirdQuantity}";
    }

    public void Build()
    {
        if(!PlayerCanBuild()) return;

        PlayerBag.Instance.Materials -= firstQuantity;
        PlayerBag.Instance.Ores -= secondQuantity;
        PlayerBag.Instance.Gold -= thirdQuantity;
        PlayerBag.Instance.SaveBag();

        barrack.Build();
        Exit();
    }

    bool PlayerCanBuild()
    {
        if(PlayerBag.Instance.Materials >= firstQuantity && PlayerBag.Instance.Ores >= secondQuantity && PlayerBag.Instance.Gold >= thirdQuantity){
            return true;
        }
        return false;
    }
    public void Exit()
    {
        Destroy(gameObject);
        Barrack.canClick = true;
    }
}
