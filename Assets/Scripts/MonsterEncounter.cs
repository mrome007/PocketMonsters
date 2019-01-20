using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEncounter : MonoBehaviour
{
    public List<MonsterEncounterInfo> MonsterEncounters;
}

[Serializable]
public class MonsterEncounterInfo
{
    public short MonsterIndex;
    public short MinLevelRange;
    public short MaxLevelRange;
    public short EncounterPercentage;
}
