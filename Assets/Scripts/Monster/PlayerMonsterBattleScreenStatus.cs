using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMonsterBattleScreenStatus : MonsterBattleScreenStatus
{
    [SerializeField]
    protected Text currentHP;
    [SerializeField]
    protected Text monsterHP;

    public override void UpdateMonsterStatus(string monsterName, ushort levelNumber, ushort currentHP, ushort monsterHP)
    {
        base.UpdateMonsterStatus(monsterName, levelNumber, currentHP, monsterHP);
        this.currentHP.text = currentHP.ToString();
        this.monsterHP.text = monsterHP.ToString();
    }
}
