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
    private short hitPointsIV;
    [SerializeField]
    private short attackIV;
    [SerializeField]
    private short defenseIV;
    [SerializeField]
    private short specialIV;
    [SerializeField]
    private short speedIV;

    [SerializeField]
    private Monster heavyMonster;

    public LightMonster(Monster hvy, short lvl = 1, short hpEV = 0, short atkEV = 0, short defEV = 0, short splEV = 0, short speEV = 0,
        short hpIV = 15, short atkIV = 15, short defIV = 15, short splIV = 15, short speIV = 15)
    {
        Initialize(hvy, lvl, hpEV, atkEV, defEV, splEV, speEV, hpIV, atkIV, defIV, splIV, speIV);
    }

    public void Initialize(Monster hvy, short lvl = 1, short hpEV = 0, short atkEV = 0, short defEV = 0, short splEV = 0, short speEV = 0,
        short hpIV = 15, short atkIV = 15, short defIV = 15, short splIV = 15, short speIV = 15)
    {
        level = lvl;

        heavyMonster = hvy;

        hitPointsEV = hpEV;
        attackEV = atkEV;
        defenseEV = defEV;
        specialEV = splEV;
        speedEV = speEV;

        hitPointsIV = hpIV;
        attackIV = atkIV;
        defenseIV = defIV;
        specialIV = splIV;
        speedIV = speIV;

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
            short statTotal = heavyMonster.BaseHP;
            statTotal += hitPointsIV;
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
            return GetStat(heavyMonster.BaseAttack, attackIV, attackEV);
        }
    }

    public short DefenseStat
    {
        get
        {
            return GetStat(heavyMonster.BaseDefense, defenseIV, defenseEV);
        }
    }

    public short SpecialStat
    {
        get
        {
            return GetStat(heavyMonster.BaseSpecial, specialIV, specialEV);
        }
    }

    public short SpeedState
    {
        get
        {
            return GetStat(heavyMonster.BaseSpeed, speedIV, speedEV);
        }
    }
}
