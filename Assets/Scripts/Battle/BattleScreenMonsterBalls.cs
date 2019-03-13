using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenMonsterBalls : MonoBehaviour
{
    [SerializeField]
    private GameObject monsterBallsParent;
    [SerializeField]
    private List<BattleScreenMonsterBall> monsterBalls;

    //TODO monsterBallInfo will contain the number of current pokemon in the party and their alive status. Will add fainted monster balls later.
    public void ShowMonsterBalls(MonsterBallBattleInformation monsterBallInfo)
    {
        monsterBallsParent.gameObject.SetActive(!monsterBallInfo.IsWildEncounter);
        var count = monsterBallInfo.NumberOfMonsters;
        foreach(var ball in monsterBalls)
        {
            ball.ShowBattleScreenMonsterBall(count > 0);
            count--;
        }
    }
}
