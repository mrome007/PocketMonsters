using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketMonsterParty : MonoBehaviour 
{
    [SerializeField]
    private List<LightMonster> party;
    private int currentIndex;

    public void AddMonster(LightMonster monster)
    {
        party = new List<LightMonster>();
        party.Add(monster);
    }

    public LightMonster GetCurrentMonster()
    {
        return party[currentIndex];
    }
}
