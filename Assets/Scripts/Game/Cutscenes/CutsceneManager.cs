using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public Cutscene currentCutscene;

    private static CutsceneManager instance;
    public static CutsceneManager Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<CutsceneManager>();
            }

            return instance;
        }
    }

    public void ShootCutscene(Cutscene cutscene){
        currentCutscene = cutscene;
        cutscene.Enter();
        cutscene.Act();
    }
}
