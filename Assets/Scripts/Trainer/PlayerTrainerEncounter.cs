using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

public class PlayerTrainerEncounter : TrainerEncounter
{
    private int currentIndex = 0;

    public void SetMonstersInfo(List<PartyMonsterInfo> mInfo)
    {
        monstersInfo = mInfo;
        MonstersInfo = new ReadOnlyCollection<PartyMonsterInfo>(monstersInfo);
    }

    public void SetMonstersInfo(PartyMonsterInfo info, bool last)
    {
        if(monstersInfo[currentIndex] != null)
        {
            monstersInfo[currentIndex] = info;
        }
        else
        {
            monstersInfo.Add(info);
        }

        currentIndex++;

        if(last || currentIndex == PocketMonsterParty.MAX_MONSTERS_IN_PARTY)
        {
            MonstersInfo = new ReadOnlyCollection<PartyMonsterInfo>(monstersInfo);
            currentIndex = 0;
        }
    }
}
