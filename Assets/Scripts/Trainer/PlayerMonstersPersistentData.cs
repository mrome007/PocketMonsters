using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonstersPersistentData : PersistentData
{
    private TrainerEncounter trainerEncounter;

    private void Awake()
    {
        trainerEncounter = GetComponent<TrainerEncounter>();
    }

    public override void SaveData()
    {
        PostSaveComplete();
    }

    public override void LoadData()
    {
        PostLoadComplete();
    }
}
