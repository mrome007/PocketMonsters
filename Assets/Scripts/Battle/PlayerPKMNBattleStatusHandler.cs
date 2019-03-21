using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPKMNBattleStatusHandler : MonoBehaviour 
{
    [SerializeField]
    private List<MonsterBattleScreenStatus> monsterStatuses;

    public void UpdatePlayerMonsterStatus(BattleStateArgs battleArgs)
    {
        ShowMonsterStatus(false);
        for(var index = 0; index < battleArgs.PlayerPartyNumber; index++)
        {
            monsterStatuses[index].gameObject.SetActive(true);
            var monsterName = battleArgs.GetPlayerMonsterName(index);
            var monsterStatus = battleArgs.GetPlayerMonsterStatus(0);
            monsterStatuses[index].UpdateMonsterStatus(monsterName, monsterStatus.Level, monsterStatus.CurrentHP, monsterStatus.HP);
        }
    }

    private void ShowMonsterStatus(bool show)
    {
        monsterStatuses.ForEach(monster => monster.gameObject.SetActive(show));
    }
}
