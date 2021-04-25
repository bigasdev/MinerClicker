using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrackButton : MonoBehaviour
{
    public Text text;

    public void Initialize(string _text)
    {
        text.text = _text;
    }
}
