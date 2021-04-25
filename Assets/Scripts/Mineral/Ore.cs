using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ore : MonoBehaviour
{
    void Start()
    {
        transform.DOMove(new Vector2(transform.position.x + 12f, transform.position.y + 15f), 2f);
    }

}
