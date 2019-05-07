using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterParty
{
    private List<PartyMonsterInfo> party;

    public MonsterParty()
    {
        party = new List<PartyMonsterInfo>(PocketMonsterParty.MAX_MONSTERS_IN_PARTY);
    }
}
