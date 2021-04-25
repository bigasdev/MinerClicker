using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public GameObject backpack;
    public GameObject hud;
    public Text score;
    void Update()
    {
        score.text = StatsManager.Instance.stats["Layer"].quantity.ToString();
    }

    public void EnterBackpack()
    {
        StateController.Instance.ChangeDefinition(StateDefinition.BACKPACK);
        backpack.SetActive(true);
        hud.SetActive(false);
    }

    public void LeaveBackpack()
    {
        StateController.Instance.ChangeDefinition(StateDefinition.GAME);
        backpack.SetActive(false);
        hud.SetActive(true);
    }
}
