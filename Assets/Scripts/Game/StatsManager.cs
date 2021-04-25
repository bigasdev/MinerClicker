using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    private static StatsManager instance;
    public Stats[] statsHolder;
    public Dictionary<string, Stats> stats = new Dictionary<string, Stats>();
    
    private void Start() {
        stats.Add("Layer", statsHolder[0]);
    }
    public static StatsManager Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<StatsManager>();
            }
            
            return instance;
        }
    }
}
