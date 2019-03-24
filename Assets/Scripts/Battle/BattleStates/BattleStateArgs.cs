using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateArgs
{
    private PocketMonsterParty player;
    private PocketMonsterParty enemy;

    public BattleStateArgs(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        this.player = player;
        this.enemy = enemy;
    }

    public bool EnemyWildEncounter
    {
        get
        {
            return enemy.WildEncounter;
        }
    }

    public PartyTrainer PlayerTrainer
    {
        get
        {
            return player.PartyTrainer;
        }
    }

    public PartyTrainer EnemyTrainer
    {
        get
        {
            return enemy.PartyTrainer;
        }
    }

    public int PlayerPartyNumber
    {
        get
        {
            return player.NumberOfMonsters;
        }
    }

    public string GetPlayerMonsterName(int index = 0)
    {
        return player.GetMonsterName(index);
    }

    public LightMonsterStatus GetPlayerMonsterStatus(int index = 0)
    {
        return player.GetMonsterStatusLight(index);
    }

    public LightMonsterStatus GetPlayerMonsterStatusDetailed(int index = 0)
    {
        return player.GetMonsterStatusLightDetailed(index);
    }

    public string GetEnemyMonsterName(int index = 0)
    {
        return enemy.GetMonsterName(index);
    }

    public LightMonsterStatus GetEnemyMonsterStatus(int index = 0)
    {
        return enemy.GetMonsterStatusLight(index);
    }

    public Sprite GetFirstMonsterSprite(bool front, bool isPlayer)
    {
        return front ? isPlayer ? player.GetMonsterSprite(0, true) : enemy.GetMonsterSprite(0, true) : 
            isPlayer ? player.GetMonsterSprite(0, false): enemy.GetMonsterSprite(0, false);
    }

    public Sprite GetMonsterSprite(int index)
    {
        return player.GetMonsterSprite(index, true);
    }

    public MonsterBallBattleInformation GetCurrentMonsterBallBattleInfo(bool player)
    {
        return new MonsterBallBattleInformation(player ? this.player : this.enemy);
    }

    public MonsterMovesBundle GetPlayerMonsterMoves(int index = 0)
    {
        return player.GetMoves(index);
    }

    public MonsterMovesBundle GetEnemyMonsterMoves(int index = 0)
    {
        return enemy.GetMoves(index);
    }


}

public struct MonsterBallBattleInformation
{
    public bool IsWildEncounter { get; private set; }
    public int NumberOfMonsters { get; private set; }
    public bool? FirstMonsterAlive { get; private set; }
    public bool? SecondMonsterAlive { get; private set; }
    public bool? ThirdMonsterAlive { get; private set; }
    public bool? FourthMonsterAlive { get; private set; }
    public bool? FifthMonsterAlive { get; private set; }
    public bool? SixthMonsterAlive { get; private set; }

    public MonsterBallBattleInformation(PocketMonsterParty party)
    {
        IsWildEncounter = party.WildEncounter;
        NumberOfMonsters = party.NumberOfMonsters;
        FirstMonsterAlive = party.IsMonsterAlive(0);
        SecondMonsterAlive = party.IsMonsterAlive(1);
        ThirdMonsterAlive = party.IsMonsterAlive(2);
        FourthMonsterAlive = party.IsMonsterAlive(3);
        FifthMonsterAlive = party.IsMonsterAlive(4);
        SixthMonsterAlive = party.IsMonsterAlive(5);
    }
}