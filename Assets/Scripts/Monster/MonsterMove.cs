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
    public string MonsterMoveName { get { return MoveName; } }

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

    public bool CanIncrement()
    {
        return currentPP < pp;
    }

    public bool CanDecrement()
    {
        return currentPP > 0;
    }

    public void IncrementCurrentPP()
    {
        if(currentPP < pp)
        {
            currentPP++;
        }
    }

    public void DecrementCurrentPP()
    {
        if(currentPP > 0)
        {
            currentPP--;
        }
    }
}

public struct MonsterMovesBundle
{
    public MonsterMoveInfo? MoveOne { get{ return moveOne; } }
    public MonsterMoveInfo? MoveTwo { get{ return moveTwo; } }
    public MonsterMoveInfo? MoveThree { get{ return moveThree; } }
    public MonsterMoveInfo? MoveFour { get{ return moveFour; } }

    private MonsterMoveInfo? moveOne;
    private MonsterMoveInfo? moveTwo;
    private MonsterMoveInfo? moveThree;
    private MonsterMoveInfo? moveFour;

    public MonsterMovesBundle(params MonsterMoveInfo?[] moves)
    {
        moveOne = null;
        moveTwo = null;
        moveThree = null;
        moveFour = null;

        for(var index = 0; index < moves.Length; index++)
        {
            switch(index)
            {
                case 0:
                    moveOne = moves[index];
                    break;
                case 1:
                    moveTwo = moves[index];
                    break;
                case 2:
                    moveThree = moves[index];
                    break;
                case 3:
                    moveFour = moves[index];
                    break;
                default:
                    break;
            }
        }
    }

    public MonsterMovesBundle(MonsterMovesBundle bundle)
    {
        moveOne = bundle.moveOne;
        moveTwo = bundle.moveTwo;
        moveThree = bundle.moveThree;
        moveFour = bundle.moveFour;
    }
}
