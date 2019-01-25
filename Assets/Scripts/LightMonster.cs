using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LightMonster
{
    [SerializeField]
    private short level;
    [SerializeField]
    private short currentHitPoints;
    [SerializeField]
    private short hitPointsEV;
    [SerializeField]
    private short attackEV;
    [SerializeField]
    private short defenseEV;
    [SerializeField]
    private short specialEV;
    [SerializeField]
    private short speedEV;
    [SerializeField]
    private Monster heavyMonster;

    public LightMonster(Monster hvy, short level = 1, short hpEV = 0, short atkEV = 0, short defEV = 0, short splEV = 0, short speEV = 0)
    {
        Initialize(level, hvy, hpEV, atkEV, defEV, splEV, speEV);
    }

    public void Initialize(short lvl, Monster hvy, short hpEV = 0, short atkEV = 0, short defEV = 0, short splEV = 0, short speEV = 0)
    {
        level = lvl;
        heavyMonster = hvy;
        hitPointsEV = hpEV;
        attackEV = atkEV;
        defenseEV = defEV;
        specialEV = splEV;
        speedEV = speEV;

        currentHitPoints = HPStat;
    }

    private short GetStat(short baseTotal, short iv, short ev)
    {
        short statTotal = baseTotal;
        statTotal += iv;
        statTotal *= (short)2;

        short evCalculation = (short)Mathf.FloorToInt(Mathf.CeilToInt(Mathf.Sqrt(1f * ev)) / 4f);
        statTotal += evCalculation;
        statTotal *= (short)level;
        statTotal /= (short)100;
        statTotal += (short)5;

        return statTotal;
    }

    public Sprite Back
    {
        get
        {
            return heavyMonster.MonsterBackSprite;   
        }
    }

    public Sprite Front
    {
        get
        {
            return heavyMonster.MonsterFrontSprite;
        }
    }

    public short HPStat
    {
        get
        {
            short statTotal = heavyMonster.BaseStatTotal;
            statTotal += heavyMonster.BaseHP;
            statTotal *= (short)2;

            short evCalculation = (short)Mathf.FloorToInt(Mathf.CeilToInt(Mathf.Sqrt(1f * hitPointsEV)) / 4f);
            statTotal += evCalculation;
            statTotal *= (short)level;
            statTotal /= (short)100;
            statTotal += level;
            statTotal += (short)10;

            return statTotal;
        }
    }

    public short AttackStat
    {
        get
        {
            return GetStat(heavyMonster.BaseStatTotal, heavyMonster.BaseAttack, attackEV);
        }
    }

    public short DefenseStat
    {
        get
        {
            return GetStat(heavyMonster.BaseStatTotal, heavyMonster.BaseDefense, defenseEV);
        }
    }

    public short SpecialStat
    {
        get
        {
            return GetStat(heavyMonster.BaseStatTotal, heavyMonster.BaseSpecial, specialEV);
        }
    }

    public short SpeedState
    {
        get
        {
            return GetStat(heavyMonster.BaseStatTotal, heavyMonster.BaseSpeed, speedEV);
        }
    }
}
