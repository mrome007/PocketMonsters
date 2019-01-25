using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterEncounter : MonoBehaviour
{
    public List<MonsterEncounterInfo> MonsterEncounters;

    public Vector2Int GetMonsterFromEncounter()
    {
        var total = (int)MonsterEncounters.Sum(encounter => encounter.EncounterPercentage);
        var rng = UnityEngine.Random.Range(0, total);

        var currentIndex = 0;
        var currentWeight = 0;
        var currentLevel = 1;
        foreach(var encounter in MonsterEncounters)
        {
            currentWeight += encounter.EncounterPercentage;
            if(rng < currentWeight)
            {
                currentLevel = UnityEngine.Random.Range(encounter.MinLevelRange, encounter.MaxLevelRange + 1);
                break;
            }
            currentIndex++;
        }

        return new Vector2Int(MonsterEncounters[currentIndex].MonsterIndex, currentLevel);
    }
}

[Serializable]
public class MonsterEncounterInfo
{
    public short MonsterIndex;
    public short MinLevelRange;
    public short MaxLevelRange;
    public short EncounterPercentage;
}
