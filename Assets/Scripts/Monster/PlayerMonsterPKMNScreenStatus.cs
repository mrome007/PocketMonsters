using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterPKMNScreenStatus : PlayerMonsterBattleScreenStatus
{
    [SerializeField]
    private List<GameObject> pkmnScreenIcons;

    public override void UpdateMonsterStatus(string monsterName, ushort levelNumber, ushort currentHP, ushort monsterHP, int icon = 0)
    {
        base.UpdateMonsterStatus(monsterName, levelNumber, currentHP, monsterHP, icon);

        ShowPKMNScreenIcons(false);
        if(icon >= 0 && icon < pkmnScreenIcons.Count)
        {
            pkmnScreenIcons[icon].SetActive(true);
        }
    }

    private void ShowPKMNScreenIcons(bool show)
    {
        pkmnScreenIcons.ForEach(icon => icon.gameObject.SetActive(show));
    }
}
