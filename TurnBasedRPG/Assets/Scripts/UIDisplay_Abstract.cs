using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIDisplay_Abstract : MonoBehaviour
{
    private void OnEnable()
    {
        UI_TurnManager.UTM.UpdateDisplay += UpdateDisplay;
    }
    private void OnDisable()
    {
        UI_TurnManager.UTM.UpdateDisplay -= UpdateDisplay;
    }

    protected abstract void UpdateDisplay(bool playerTurn);
}
