using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralManager : MonoBehaviour
{
    private static MineralManager instance;

    public static MineralManager Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<MineralManager>();
            }
            return instance;
        }
    }

    public void DropOre(string _ore, Vector2 position){
       var ore = Resources.Load<Ore>("Prefabs/Ores/" + _ore + "_Ore");
       Instantiate(ore, position, Quaternion.identity);
    }
}
