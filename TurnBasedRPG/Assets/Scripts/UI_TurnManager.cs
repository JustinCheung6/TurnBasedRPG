using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TurnManager : MonoBehaviour
{
    public static UI_TurnManager UTM = null;

    [SerializeField] private Canvas playerCanvas = null;

    public delegate void displayUpdate(bool playerTurn);
    public displayUpdate UpdateDisplay;

    private bool TMConnected = true;

    private void OnEnable()
    {
        if (TurnManager.TM != null)
            TurnManager.TM.StartTurn += NewTurn;
        else
            TMConnected = false;

        if (UTM == null)
            UTM = this;
        else if (UTM != this)
            Destroy(this);
    }
    private void OnDisable()
    {
        if(!TMConnected)
            if(TurnManager.TM != null)
                TurnManager.TM.StartTurn += NewTurn;
    }

    private void Update()
    {
        if (TurnManager.TM != null)
            TurnManager.TM.StartTurn += NewTurn;
    }

    private void NewTurn(Character c)
    {
        if (c.IsPlayer)
        {
            playerCanvas.enabled = true;
        }
        else
        {
            playerCanvas.enabled = false;
        }

        if (c.IsEnemy)
            StartCoroutine(EnemyTurn());

        UpdateDisplay?.Invoke(c.IsPlayer);
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1.5f);
        TurnManager.TM.NextTurn();
    }
}
