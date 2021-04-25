using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game instance;
    public static Game Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<Game>();
            }
            return instance;
        }
    }
    public Cutscene firstCutscene;
    public GameObject Hud;
    void Start()
    {
        CutsceneManager.Instance.ShootCutscene(firstCutscene);
    }

    [ContextMenu("Delete data")]
    void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
