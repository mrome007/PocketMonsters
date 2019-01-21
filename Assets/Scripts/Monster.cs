using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Sprite MonsterFrontSprite;
    public Sprite MonsterBackSprite;
    public Monster Evolution;

    public short MonsterNumber;
    public string MonsterName;

    public enum MonsterType
    {
        NONE,
        NORMAL,
        FIGHTING,
        FLYING,
        POISON,
        GROUND,
        ROCK,
        BUG,
        STEEL,
        FIRE,
        WATER,
        GRASS,
        ELECTRIC,
        PSYCHIC,
        ICE,
        DRAGON,
        DARK,
        FAIRY,
        GHOST
    }

    public MonsterType PrimaryType;
    public MonsterType SecondaryType;

    public short BaseStatTotal { get; private set; }

    public short BaseHP;
    public short BaseAttack;
    public short BaseDefense;
    public short BaseSpecial;
    public short BaseSpeed;

    private void Awake()
    {
        InitializeBaseTotal();
    }

    private void InitializeBaseTotal()
    {
        BaseStatTotal = (short)0;
        BaseStatTotal += BaseHP;
        BaseStatTotal += BaseAttack;
        BaseStatTotal += BaseDefense;
        BaseStatTotal += BaseSpecial;
        BaseStatTotal += BaseSpeed;
    }
}
