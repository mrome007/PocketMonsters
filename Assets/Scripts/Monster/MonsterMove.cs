using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour 
{
    public string MoveName;
    public MonsterType MoveType;
    public MonsterMoveCategory MoveCategory;
    public byte Power;
    public byte Accuracy;
    public byte PP;
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
