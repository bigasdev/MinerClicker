using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour
{
    public Monster[] monsters;

    private static MonsterData instance;

    public static MonsterData Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<MonsterData>();
            }
            return instance;
        }
    }
}
