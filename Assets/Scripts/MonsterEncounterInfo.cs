using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterEncounterInfo : MonoBehaviour
{
    public Monster Monster;
    public MonsterLevelRange LevelRange;
    public float EncounterPercentage;
}

[Serializable]
public class MonsterLevelRange
{
    public int MaxLevel;
    public int MinLevel;
}
