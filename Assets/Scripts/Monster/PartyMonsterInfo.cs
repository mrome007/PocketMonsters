using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PartyMonsterInfo
{
    public int MonsterIndex { get { return monsterIndex; } }
    public int MonsterLevel { get { return monsterLevel; } }
    public PartyMonsterInfo MoveOne { get { return move1; } }
    public PartyMonsterMoveInfo MoveTwo { get { return move2; } }
    public PartyMonsterMoveInfo MoveThree { get { return move3; } }
    public PartyMonsterInfo MoveFour { get { return move4; } }


    [SerializeField]
    private int monsterIndex;
    [SerializeField]
    private int monsterLevel;
    [SerializeField]
    private PartyMonsterInfo move1;
    [SerializeField]
    private PartyMonsterMoveInfo move2;
    [SerializeField]
    private PartyMonsterMoveInfo move3;
    [SerializeField]
    private PartyMonsterInfo move4;
}
