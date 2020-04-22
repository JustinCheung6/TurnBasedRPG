using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum Alignment
    {
        enemy = -1,
        noData = 0,
        player = 1
    }

    [SerializeField] private Alignment alignment = (Alignment) 0;
    private StatSheet statSheet;
    private Equipped equipment;

    //Getters
    public Alignment Type { get => alignment; }
    public bool IsPlayer { get => (alignment == Alignment.player); }
    public bool IsEnemy { get => (alignment == Alignment.enemy); }
    public StatSheet Stats { get => statSheet; }

    private void Awake()
    {
        statSheet = new StatSheet(10, 2);
        equipment = new Equipped();
    }
}
