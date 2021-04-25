using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Monsters/New monster")]
public class Monster : ScriptableObject
{
    public string monsterName;
    public int monsterHealth;
    public int monsterDrop;
    public Sprite monsterSprite;
    public Sprite monsterAttackSprite;
}
