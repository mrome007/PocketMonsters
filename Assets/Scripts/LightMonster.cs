using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LightMonster
{
    [SerializeField]
    private ushort level;

    [SerializeField]
    private ushort currentHitPoints;

    [SerializeField]
    private ushort hitPointsEV;
    [SerializeField]
    private ushort attackEV;
    [SerializeField]
    private ushort defenseEV;
    [SerializeField]
    private ushort specialEV;
    [SerializeField]
    private ushort speedEV;

    [SerializeField]
    private ushort hitPointsIV;
    [SerializeField]
    private ushort attackIV;
    [SerializeField]
    private ushort defenseIV;
    [SerializeField]
    private ushort specialIV;
    [SerializeField]
    private ushort speedIV;

    [SerializeField]
    private Monster heavyMonster;

    public LightMonster(Monster hvy, ushort lvl = 1, ushort hpEV = 0, ushort atkEV = 0, ushort defEV = 0, ushort splEV = 0, ushort speEV = 0,
        ushort hpIV = 15, ushort atkIV = 15, ushort defIV = 15, ushort splIV = 15, ushort speIV = 15)
    {
        Initialize(hvy, lvl, hpEV, atkEV, defEV, splEV, speEV, hpIV, atkIV, defIV, splIV, speIV);
    }

    public void Initialize(Monster hvy, ushort lvl = 1, ushort hpEV = 0, ushort atkEV = 0, ushort defEV = 0, ushort splEV = 0, ushort speEV = 0,
        ushort hpIV = 15, ushort atkIV = 15, ushort defIV = 15, ushort splIV = 15, ushort speIV = 15)
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

    private ushort GetStat(ushort baseTotal, ushort iv, ushort ev)
    {
        ushort statTotal = baseTotal;
        statTotal += iv;
        statTotal *= (ushort)2;

        ushort evCalculation = (ushort)Mathf.FloorToInt(Mathf.CeilToInt(Mathf.Sqrt(1f * ev)) / 4f);
        statTotal += evCalculation;
        statTotal *= (ushort)level;
        statTotal /= (ushort)100;
        statTotal += (ushort)5;

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

    public ushort HPStat
    {
        get
        {
            ushort statTotal = heavyMonster.BaseHP;
            statTotal += hitPointsIV;
            statTotal *= (ushort)2;

            ushort evCalculation = (ushort)Mathf.FloorToInt(Mathf.CeilToInt(Mathf.Sqrt(1f * hitPointsEV)) / 4f);
            statTotal += evCalculation;
            statTotal *= (ushort)level;
            statTotal /= (ushort)100;
            statTotal += level;
            statTotal += (ushort)10;

            return statTotal;
        }
    }

    public ushort AttackStat
    {
        get
        {
            return GetStat(heavyMonster.BaseAttack, attackIV, attackEV);
        }
    }

    public ushort DefenseStat
    {
        get
        {
            return GetStat(heavyMonster.BaseDefense, defenseIV, defenseEV);
        }
    }

    public ushort SpecialStat
    {
        get
        {
            return GetStat(heavyMonster.BaseSpecial, specialIV, specialEV);
        }
    }

    public ushort SpeedState
    {
        get
        {
            return GetStat(heavyMonster.BaseSpeed, speedIV, speedEV);
        }
    }
}
