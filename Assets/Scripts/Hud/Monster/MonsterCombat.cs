using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
public class MonsterCombat : MonoBehaviour, IPointerClickHandler
{
    public CombatHud hud;
    public RectTransform position;
    public float attackCooldown;
    bool isAttacking = false;
    int attackIndex;
    public void OnPointerClick(PointerEventData pointerEventData){
         if(attackCooldown > 0) return;
         hud.monsterHealth--;
         transform.DOPunchScale(new Vector3(-.15f, -.15f, 1f), .5f, 1, 1);
         attackCooldown = .5f;
    }
    
    private void Update() {
        position.anchoredPosition = Vector2.Lerp(position.anchoredPosition, new Vector2(position.anchoredPosition.x, isAttacking ? -450f : 91f), Time.deltaTime * 14f);

        hud.attackSlider.value += Time.deltaTime;
        if(hud.attackSlider.value == 5)
        {
            StartCoroutine(Attack());
            hud.attackSlider.value = 0;
        }
        if(attackCooldown <= 0) return;
        
        attackCooldown -= Time.deltaTime;
    }

    IEnumerator Attack(){
       hud.monsterSprite.sprite = hud.monster.monsterAttackSprite;
       hud.monsterSprite.SetNativeSize();
       yield return new WaitForSeconds(.5f);
       isAttacking = true;
       yield return new WaitForSeconds(.5f);
       hud.monsterSprite.sprite = hud.monster.monsterSprite;
       hud.monsterSprite.SetNativeSize();
       isAttacking = false;
       Player.Instance.health--;
       attackIndex++;
    }
    
}
