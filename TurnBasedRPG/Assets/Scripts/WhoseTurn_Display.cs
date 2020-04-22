using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhoseTurn_Display : UIDisplay_Abstract
{
    private Text display;

    private void Awake()
    {
        display = GetComponent<Text>();
    }

    protected override void UpdateDisplay(bool playerTurn)
    {
        if (playerTurn)
            display.text = "Player's Turn";
        else
            display.text = "Enemy's Turn";
    }
}
