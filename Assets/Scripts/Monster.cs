using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum MonsterType
    {
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
        FAIRY
    }

    public MonsterType PrimaryType;
    public MonsterType SecondaryType;

    public short BaseStatTotal { get; private set; }

    public short BaseHP;
    public short BaseAttack;
    public short BaseDefense;
    public short BaseSpecial;
    public short BaseSpeed;

    public short EVHP;
    public short EVAttack;
    public short EVDefense;
    public short EVSpecial;
    public short EVSpeed;

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
