using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPocketMonsterParty : PocketMonsterParty
{
    //TEMPORARY JUST TO GRAB PLAYER'S POKEMON.
    private TrainerEncounter playerTrainer;
    //GRAB POKEMON MONSTER INFO FROM SAVED FILE IN THE FUTURE.

    protected override void Awake()
    {
        playerTrainer = GetComponent<TrainerEncounter>();
        base.Awake();
    }

    protected override void HandleMonstersPopulated()
    {
        base.HandleMonstersPopulated();
        AddMonster(playerTrainer.MonstersInfo);
    }

}
