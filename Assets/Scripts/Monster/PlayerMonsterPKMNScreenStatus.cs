using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMonsterPKMNScreenStatus : PlayerMonsterBattleScreenStatus
{
    [SerializeField]
    private List<Sprite> pkmnScreenIcons;

    [SerializeField]
    private Image monsterIconImage;

    public override void UpdateMonsterStatus(string monsterName, ushort levelNumber, ushort currentHP, ushort monsterHP, int icon = 0)
    {
        base.UpdateMonsterStatus(monsterName, levelNumber, currentHP, monsterHP, icon);

        if(icon >= 0 && icon < pkmnScreenIcons.Count)
        {
            monsterIconImage.sprite = pkmnScreenIcons[icon];
        }
    }
}
