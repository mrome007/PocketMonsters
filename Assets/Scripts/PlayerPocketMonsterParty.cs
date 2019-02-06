using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPocketMonsterParty : PocketMonsterParty
{
    private void Start()
    {
        //Temporary just to show pikachu.
        AddMonster(new LightMonster(HeavyMonsters.GetHeavyReference(25), 5, 0, 0, 0, 49, 81), false);
    }
}
