using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterParty
{
    private List<PartyMonsterInfo> party;

    public PartyMonsterInfo this[int i]
    {
        get { return party[i]; }
    }

    public MonsterParty()
    {
        party = new List<PartyMonsterInfo>(PocketMonsterParty.MAX_MONSTERS_IN_PARTY);

        for(var count = 0; count < PocketMonsterParty.MAX_MONSTERS_IN_PARTY; count++)
        {
            party.Add(new PartyMonsterInfo());
        }
    }

    public void AddMonsterToParty(int index, PartyMonsterInfo info)
    {
        if(index < 0 || index >= PocketMonsterParty.MAX_MONSTERS_IN_PARTY)
        {
            return;
        }

        party[index].Initialize(info);
    }
}
