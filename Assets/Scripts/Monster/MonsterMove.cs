using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour 
{
    [SerializeField]
    private int MonsterIndex;
    [SerializeField]
    private string MoveName;
    [SerializeField]
    private MonsterType MoveType;
    [SerializeField]
    private MonsterMoveCategory MoveCategory;
    [SerializeField]
    private byte Power;
    [SerializeField]
    private byte Accuracy;
    [SerializeField]
    private byte PP;

    public int MIndex { get{ return MonsterIndex; } set { MonsterIndex = value; } } 

    public MonsterMoveInfo GetMonsterMoveInfoFromMonsterMove(byte currentPP = 0)
    {
        return new MonsterMoveInfo(MonsterIndex, MoveCategory, currentPP, PP);
    }
}

public enum MonsterMoveCategory
{
    NONE,
    PHYSICAL,
    SPECIAL,
    STATUS
}

[Serializable]
public class PartyMonsterMoveInfo
{
    public int MonsterMoveIndex { get { return monsterMoveIndex; } }
    public byte CurrentPP { get { return currentPP; } }
    public byte PP { get { return pp; } }

    [SerializeField]
    private int monsterMoveIndex;
    [SerializeField]
    private byte currentPP;
    [SerializeField]
    private byte pp;
}

public struct MonsterMoveInfo
{
    public int MonsterMoveIndex { get { return monsterMoveIndex; } }
    public MonsterMoveCategory MoveType { get { return moveType; } }
    public byte CurrentPP { get { return currentPP; } }
    public byte PP { get { return pp; } }

    private int monsterMoveIndex;
    private MonsterMoveCategory moveType;
    private byte currentPP;
    private byte pp;

    public MonsterMoveInfo(int index, MonsterMoveCategory category, byte cur, byte pp)
    {
        monsterMoveIndex = index;
        moveType = category;
        currentPP = cur;
        this.pp = pp;
    }
}
