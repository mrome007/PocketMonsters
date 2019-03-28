using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchMonsterBattleSequence : SwitchMonsterBattleSequence
{
    protected override void HandleCurrentMonsterAnimationEnded()
    {
        textBox.PopulateText(BattleTextType.GOPOKEMON, bArgs.GetPlayerMonsterName());

        base.HandleCurrentMonsterAnimationEnded();
    }

    protected override void HandleNewSwitchActionComplete()
    {
        base.HandleNewSwitchActionComplete();

        var status = bArgs.GetPlayerMonsterStatus();
        var name = bArgs.GetPlayerMonsterName();
        battleStatus.UpdateMonsterStatus(name, status.Level, status.CurrentHP, status.HP);
    }
}
