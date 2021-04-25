using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartScene : Cutscene
{
    private GameObject player;

    public override void Act()
    {
        StartCoroutine(changeCutscene(1.5f));
        player = GameObject.FindGameObjectWithTag("Player");
        var spot = GameObject.FindGameObjectWithTag("MineSpot");

        player.transform.DOMove(spot.transform.position, 1.5f, false);
    }
} 
