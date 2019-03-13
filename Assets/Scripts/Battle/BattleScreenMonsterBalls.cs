using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenMonsterBalls : MonoBehaviour
{
    [SerializeField]
    private GameObject monsterBallsParent;
    [SerializeField]
    private List<BattleScreenMonsterBall> monsterBalls;

    public void ShowMonsterBalls(MonsterBallBattleInformation monsterBallInfo)
    {
        monsterBallsParent.gameObject.SetActive(!monsterBallInfo.IsWildEncounter);
        var count = monsterBallInfo.NumberOfMonsters;
        monsterBalls[0].ShowBattleScreenMonsterBall(count > 0, monsterBallInfo.FirstMonsterAlive ?? false);
        count--;     
        monsterBalls[1].ShowBattleScreenMonsterBall(count > 0, monsterBallInfo.SecondMonsterAlive ?? false);
        count--;
        monsterBalls[2].ShowBattleScreenMonsterBall(count > 0, monsterBallInfo.ThirdMonsterAlive ?? false);
        count--;
        monsterBalls[3].ShowBattleScreenMonsterBall(count > 0, monsterBallInfo.FourthMonsterAlive ?? false);
        count--;
        monsterBalls[4].ShowBattleScreenMonsterBall(count > 0, monsterBallInfo.FifthMonsterAlive ?? false);
        count--;
        monsterBalls[5].ShowBattleScreenMonsterBall(count > 0, monsterBallInfo.SixthMonsterAlive ?? false);
    }
}
