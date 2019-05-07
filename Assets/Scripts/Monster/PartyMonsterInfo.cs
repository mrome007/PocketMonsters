using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PartyMonsterInfo
{
    public int MonsterIndex { get { return monsterIndex; } }
    public int MonsterLevel { get { return monsterLevel; } }

    private int HitPointsEV { get { return hitPointsEV; } }
    private int AttackEV { get { return attackEV; } }
    private int DefenseEV { get { return defenseEV; } }
    private int SpecialEV { get { return specialEV; } }
    private int SpeedEV { get { return speedEV; } }

    private int HitPointsIV { get { return hitPointsIV; } }
    private int AttackIV { get { return attackIV; } }
    private int DefenseIV { get { return defenseIV; } }
    private int SpecialIV { get { return specialIV; } }
    private int SpeedIV { get { return speedIV; } }

    public PartyMonsterMoveInfo MoveOne { get { return move1; } }
    public PartyMonsterMoveInfo MoveTwo { get { return move2; } }
    public PartyMonsterMoveInfo MoveThree { get { return move3; } }
    public PartyMonsterMoveInfo MoveFour { get { return move4; } }


    [SerializeField]
    private int monsterIndex;
    [SerializeField]
    private int monsterLevel;

    [SerializeField]
    private int hitPointsEV = 0;
    [SerializeField]
    private int attackEV = 0;
    [SerializeField]
    private int defenseEV = 0;
    [SerializeField]
    private int specialEV = 0;
    [SerializeField]
    private int speedEV = 0;

    [SerializeField]
    private int hitPointsIV = 15;
    [SerializeField]
    private int attackIV = 15;
    [SerializeField]
    private int defenseIV = 15;
    [SerializeField]
    private int specialIV = 15;
    [SerializeField]
    private int speedIV = 15;

    [SerializeField]
    private PartyMonsterMoveInfo move1;
    [SerializeField]
    private PartyMonsterMoveInfo move2;
    [SerializeField]
    private PartyMonsterMoveInfo move3;
    [SerializeField]
    private PartyMonsterMoveInfo move4;

    public void Initialize(PartyMonsterInfo info)
    {
        this.monsterIndex = info.monsterIndex;
        this.monsterLevel = info.monsterLevel;

        this.hitPointsEV = info.hitPointsEV;
        this.attackEV = info.attackEV;
        this.defenseEV = info.defenseEV;
        this.specialEV = info.specialEV;
        this.speedEV = info.speedEV;

        this.hitPointsIV = info.hitPointsIV;
        this.attackIV = info.attackIV;
        this.defenseIV = info.defenseIV;
        this.specialIV = info.specialIV;
        this.speedIV = info.speedIV;

        this.move1.Initialize(info.move1);
        this.move2.Initialize(info.move2);
        this.move3.Initialize(info.move3);
        this.move4.Initialize(info.move4);
    }
}
