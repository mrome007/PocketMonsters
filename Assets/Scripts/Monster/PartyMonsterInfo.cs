using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PartyMonsterInfo
{
    public int MonsterIndex { get { return monsterIndex; } }
    public int MonsterLevel { get { return monsterLevel; } }
    public string MoveOne { get { return move1; } }
    public string MoveTwo { get { return move2; } }
    public string MoveThree { get { return move3; } }
    public string MoveFour { get { return move4; } }


    [SerializeField]
    private int monsterIndex;
    [SerializeField]
    private int monsterLevel;
    [SerializeField]
    private string move1;
    [SerializeField]
    private string move2;
    [SerializeField]
    private string move3;
    [SerializeField]
    private string move4;
}
