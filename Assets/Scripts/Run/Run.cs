using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public Vector2 firstSpawnPosition;
    public Layers currentLayer;
    public GameObject[] terrainLayer, stoneLayer, griotinaLayer, azuricLayer, golstenLayer,
                        scarletineLayer, mithriliumLayer, adamorinalLayer, telodiumLayer;
    private const string final = "_Layer";
    private const int layerNumbers = 100;

    private void Start() {
        terrainLayer = new GameObject[15];
        stoneLayer = new GameObject[25];
        griotinaLayer = new GameObject[25];
        azuricLayer = new GameObject[25];
        golstenLayer = new GameObject[50];
        scarletineLayer = new GameObject[50];
        mithriliumLayer = new GameObject[50];
        adamorinalLayer = new GameObject[75];
        telodiumLayer = new GameObject[75];
        
        CreateObjects();
        CreateRun();
    }

    void CreateObjects(){
        for(int i = 0; i < terrainLayer.Length; i++){
            terrainLayer[i] = LoadLayer("Terrain");
        }
        for(int i = 0; i < stoneLayer.Length; i++){
            stoneLayer[i] = LoadLayer("Stone");
        }
        for(int i = 0; i < griotinaLayer.Length; i++){
            griotinaLayer[i] = LoadLayer("Griotina");
        }
        for(int i = 0; i < azuricLayer.Length; i++){
            azuricLayer[i] = LoadLayer("Azuric");
        }
        for(int i = 0; i < golstenLayer.Length; i++){
            golstenLayer[i] = LoadLayer("Golsten");
        }
        for(int i = 0; i < scarletineLayer.Length; i++){
            scarletineLayer[i] = LoadLayer("Scarletine");
        }
        for(int i = 0; i < mithriliumLayer.Length; i++){
            mithriliumLayer[i] = LoadLayer("Mithrilium");
        }
        for(int i = 0; i < adamorinalLayer.Length; i++){
            adamorinalLayer[i] = LoadLayer("Adamorinal");
        }
        for(int i = 0; i < telodiumLayer.Length; i++){
            telodiumLayer[i] = LoadLayer("Telodium");
        }
    }

    GameObject LoadLayer(string _layer){
        var layer = Resources.Load<GameObject>("Prefabs/Layers/" + _layer + final);
        return layer;
    }

    void CreateRun(){
        for(int i = 0; i < terrainLayer.Length; i++){
            var layer = Instantiate(terrainLayer[i], firstSpawnPosition, Quaternion.identity);
            if(i == terrainLayer.Length - 1) layer.GetComponentInChildren<Mineral>().isBossTile = true;
            firstSpawnPosition.y -= .5f;
        }
        for(int i = 0; i < stoneLayer.Length; i++){
            var layer = Instantiate(stoneLayer[i], firstSpawnPosition, Quaternion.identity);
            if(i == stoneLayer.Length - 1) layer.GetComponentInChildren<Mineral>().isBossTile = true;
            firstSpawnPosition.y -= .5f;
        }
        for(int i = 0; i < griotinaLayer.Length; i++){
            var layer = Instantiate(griotinaLayer[i], firstSpawnPosition, Quaternion.identity);
            if(i == griotinaLayer.Length - 1) layer.GetComponentInChildren<Mineral>().isBossTile = true;
            firstSpawnPosition.y -= .5f;
        }
        for(int i = 0; i < azuricLayer.Length; i++){
            var layer = Instantiate(azuricLayer[i], firstSpawnPosition, Quaternion.identity);
            if(i == azuricLayer.Length - 1) layer.GetComponentInChildren<Mineral>().isBossTile = true;
            firstSpawnPosition.y -= .5f;
        }
        for(int i = 0; i < golstenLayer.Length; i++){
            var layer = Instantiate(golstenLayer[i], firstSpawnPosition, Quaternion.identity);
            if(i == golstenLayer.Length - 1) layer.GetComponentInChildren<Mineral>().isBossTile = true;
            firstSpawnPosition.y -= .5f;
        }
        for(int i = 0; i < scarletineLayer.Length; i++){
            var layer = Instantiate(scarletineLayer[i], firstSpawnPosition, Quaternion.identity);
            if(i == scarletineLayer.Length - 1) layer.GetComponentInChildren<Mineral>().isBossTile = true;
            firstSpawnPosition.y -= .5f;
        }
        for(int i = 0; i < mithriliumLayer.Length; i++){
            var layer = Instantiate(mithriliumLayer[i], firstSpawnPosition, Quaternion.identity);
            if(i == mithriliumLayer.Length - 1) layer.GetComponentInChildren<Mineral>().isBossTile = true;
            firstSpawnPosition.y -= .5f;
        }
        for(int i = 0; i < adamorinalLayer.Length; i++){
            var layer = Instantiate(adamorinalLayer[i], firstSpawnPosition, Quaternion.identity);
            if(i == adamorinalLayer.Length - 1) layer.GetComponentInChildren<Mineral>().isBossTile = true;
            firstSpawnPosition.y -= .5f;
        }
        for(int i = 0; i < telodiumLayer.Length; i++){
            var layer = Instantiate(telodiumLayer[i], firstSpawnPosition, Quaternion.identity);
            if(i == telodiumLayer.Length - 1) layer.GetComponentInChildren<Mineral>().isBossTile = true;
            firstSpawnPosition.y -= .5f;
        }
    }
}
public enum Layers{
    Terrain,
    Stone
}
