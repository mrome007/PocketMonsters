using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMonster : MonoBehaviour
{
    private short level;
    private Monster heavyMonster;
    private short currentHitPoints;
    private short hitPointsEV;
    private short attackEV;
    private short defenseEV;
    private short specialEV;
    private short speedEV;

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
