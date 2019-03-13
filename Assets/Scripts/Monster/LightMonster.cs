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
    private ushort currentExpPoints;

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
        currentExpPoints = 0;
    }

    private ushort GetStat(ushort baseTotal, ushort iv, ushort ev)
    {
        var statTotal = baseTotal;
        statTotal += iv;
        statTotal *= 2;

        var evCalculation = (ushort)Mathf.FloorToInt(Mathf.CeilToInt(Mathf.Sqrt(1f * ev)) / 4f);
        statTotal += evCalculation;
        statTotal *= level;
        statTotal /= 100;
        statTotal += 5;

        return statTotal;
    }

    public string MonsterName
    {
        get
        {
            return heavyMonster.MonsterName;
        }
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

    public ushort CurrentHP
    {
        get
        {
            return currentHitPoints;
        }
    }

    public ushort HPStat
    {
        get
        {
            var statTotal = heavyMonster.BaseHP;
            statTotal += hitPointsIV;
            statTotal *= 2;

            var evCalculation = (ushort)Mathf.FloorToInt(Mathf.CeilToInt(Mathf.Sqrt(1f * hitPointsEV)) / 4f);
            statTotal += evCalculation;
            statTotal *= level;
            statTotal /= 100;
            statTotal += level;
            statTotal += 10;

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

    public ushort ToNextLevel
    {
        get
        {
            var nextLevel = level;
            nextLevel += 1;
            var toNext = CalculateExperience(heavyMonster.ExperienceGroup, nextLevel);
            toNext -= CalculateExperience(heavyMonster.ExperienceGroup, level);
            return toNext;
        }
    }

    private ushort CalculateExperience(MonsterExpGroup expGroup, ushort lvl)
    {
        ushort exp = 0;
        switch(expGroup)
        {
            case MonsterExpGroup.FAST:
                exp = 4;
                exp *= lvl;
                exp *= lvl;
                exp *= lvl;
                exp /= 5;
                break;
            case MonsterExpGroup.MEDIUMFAST:
                exp = lvl;
                exp *= lvl;
                exp *= lvl;
                break;
            case MonsterExpGroup.MEDIUMSLOW:
                exp = 6;
                exp *= lvl;
                exp *= lvl;
                exp *= lvl;
                exp /= 5;
                ushort square = 15;
                square *= lvl;
                square *= lvl;
                ushort one = 100;
                one *= lvl;
                exp -= square;
                exp += one;
                exp -= 140;
                break;
            case MonsterExpGroup.SLOW:
                exp = 5;
                exp *= lvl;
                exp *= lvl;
                exp *= lvl;
                exp /= 4;
                break;
            default:
                break;
        }

        return exp;
    }
}
