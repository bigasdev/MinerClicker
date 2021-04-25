using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    public int Health;
    public string oreName;

    public Sprite oreSprite;
    public SpriteRenderer[] oreRenderers;

    public GameObject[] breakingEffect;
    
    public int oreLuck;
    public bool isBossTile = false;
    private void Start() {
        oreLuck = Random.Range(0, 99);

        if(oreLuck <= 20){
           oreRenderers[0].sprite = oreSprite;
           oreRenderers[1].sprite = oreSprite;
        }
    }

    public void ReduceHealth(int damage){
        Health -= damage;

        breakingEffect[Health].SetActive(true);

        if(Health == 0){
            if(oreLuck <= 20) {
                var ore = PlayerPrefs.GetInt("Ores") + 1;
                var typeOre = PlayerPrefs.GetInt(oreName) + 1;
                PlayerPrefs.SetInt("Ores", ore);
                PlayerPrefs.SetInt(oreName, typeOre);
                PlayerBag.Instance.SaveBag();
                MineralManager.Instance.DropOre(oreName, transform.position);
            }
            Destroy(gameObject);
            StatsManager.Instance.stats["Layer"].IncreaseQuantity();

            if(!isBossTile) { int luck = Random.Range(0, 99);

            if(luck <= 15 && StatsManager.Instance.stats["Layer"].Quantity > 5){
               FindObjectOfType<HudManager>().gameObject.SetActive(false);

               var monster = Resources.Load<Monster>("Data/Monsters/" + oreName + "_Crab");

               //int monster = Random.Range(0, MonsterData.Instance.monsters.Length);
               int attacks = Random.Range(1, 4);

               var combatHud = Resources.Load<CombatHud>("Prefabs/Hud/CombatView");
               combatHud.Initialize(monster, attacks);
               Instantiate(combatHud);
             }
            }

            else
            {
               FindObjectOfType<HudManager>().gameObject.SetActive(false);

               var monster = Resources.Load<Monster>("Data/Monsters/" + oreName + "_Golem");

               var combatHud = Resources.Load<CombatHud>("Prefabs/Hud/CombatView");
               combatHud.Initialize(monster, 1);
               Instantiate(combatHud);
            }

        }
    }
}
