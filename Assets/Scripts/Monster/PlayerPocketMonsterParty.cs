using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPocketMonsterParty : PocketMonsterParty
{
    private TrainerEncounter playerTrainer;
    private PersistentData monstersData;

    protected override void Awake()
    {
        base.Awake();

        playerTrainer = GetComponent<TrainerEncounter>();
        monstersData = GetComponent<PersistentData>();
        monstersData.LoadComplete += HandleLoadMonstersComplete;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        monstersData.LoadComplete -= HandleLoadMonstersComplete;
    }

    private void HandleLoadMonstersComplete()
    {
        AddMonster(playerTrainer.MonstersParty);
    }
}
