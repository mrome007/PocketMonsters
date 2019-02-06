using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenMonsterBalls : MonoBehaviour
{
    [SerializeField]
    private List<BattleScreenMonsterBall> monsterBalls;

    public void ShowMonsterBalls(PocketMonsterParty party)
    {
        var count = party.NumberOfMonsters;
        foreach(var ball in monsterBalls)
        {
            ball.ShowBattleScreenMonsterBall(count != 0);
            count--;
        }
    }
}
