using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager TM = null;

    //List of who goes first
    private List<Character> initiativeList;

    [SerializeField] private int currentTurn = 0;

    public delegate void Update_Turn(Character c);
    public Update_Turn StartTurn;

    private void Awake()
    {
        if (TM == null)
            TM = this;
        else if (TM != this)
            Destroy(this);

        initiativeList = TurnOrder();
        
        NextTurn();
    }

    private void NewTurn(Character c)
    {
        if (StartTurn != null)
            StartTurn(c);

        if(c.Type == Character.Alignment.player)
            Debug.Log("Player's Turn");
        else if(c.Type == Character.Alignment.enemy)
            Debug.Log("Enemy's Turn");
    }

    public void NextTurn()
    {
        //Update the turn number
        if (currentTurn == initiativeList.Count)
            currentTurn = 1;
        else if (currentTurn < initiativeList.Count)
            currentTurn++;

        NewTurn(initiativeList[currentTurn - 1]);
    }

    private List<Character> TurnOrder() 
    { 
        List<Character> turnOrder = new List<Character>();

        foreach(Character c in FindObjectsOfType<Character>())
        {
            if (c.Type == Character.Alignment.player)
                turnOrder.Insert(0, c);

            else if (c.Type == Character.Alignment.enemy)
                turnOrder.Add(c);
        }
        return turnOrder;
    }


}
