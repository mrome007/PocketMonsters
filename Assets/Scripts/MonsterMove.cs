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
