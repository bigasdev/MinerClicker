using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    private static PlayerBag instance;
    public static PlayerBag Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<PlayerBag>();
            }
            return instance;
        }
    }

    public int Materials, Ores, Gold;
    
    public int Scopia, Irolite, Griotina, Azuric, Golsten, Scarletine, Mithrilium, Adamorinal, Telodium;
    public void Start()
    {
        Materials = PlayerPrefs.GetInt("Materials");
        Ores = PlayerPrefs.GetInt("Ores");
        Gold = PlayerPrefs.GetInt("Gold");

        Scopia = PlayerPrefs.GetInt("Scopia");
        Irolite = PlayerPrefs.GetInt("Irolite");
        Griotina = PlayerPrefs.GetInt("Griotina");
        Azuric = PlayerPrefs.GetInt("Azuric");
        Golsten = PlayerPrefs.GetInt("Golsten");
        Scarletine = PlayerPrefs.GetInt("Scarletine");
        Mithrilium = PlayerPrefs.GetInt("Mithrilium");
        Adamorinal = PlayerPrefs.GetInt("Adamorinal");
        Telodium = PlayerPrefs.GetInt("Telodium");
    }

    public void SaveBag()
    {
        PlayerPrefs.Save();
        Materials = PlayerPrefs.GetInt("Materials");
        Ores = PlayerPrefs.GetInt("Ores");
        Gold = PlayerPrefs.GetInt("Gold");

        
        Scopia = PlayerPrefs.GetInt("Scopia");
        Irolite = PlayerPrefs.GetInt("Irolite");
        Griotina = PlayerPrefs.GetInt("Griotina");
        Azuric = PlayerPrefs.GetInt("Azuric");
        Golsten = PlayerPrefs.GetInt("Golsten");
        Scarletine = PlayerPrefs.GetInt("Scarletine");
        Mithrilium = PlayerPrefs.GetInt("Mithrilium");
        Adamorinal = PlayerPrefs.GetInt("Adamorinal");
        Telodium = PlayerPrefs.GetInt("Telodium");
    }
}
