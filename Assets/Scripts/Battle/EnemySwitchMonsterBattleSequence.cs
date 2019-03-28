using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitchMonsterBattleSequence : SwitchMonsterBattleSequence
{
    protected override void HandleCurrentMonsterAnimationEnded()
    {
        textBox.PopulateText(BattleTextType.TRAINERGOPOKEMON, Trainers.GetTrainerName(bArgs.EnemyTrainer), bArgs.GetPlayerMonsterName());

        base.HandleCurrentMonsterAnimationEnded();
    }

    protected override void HandleNewSwitchActionComplete()
    {
        base.HandleNewSwitchActionComplete();

        var status = bArgs.GetEnemyMonsterStatus();
        var name = bArgs.GetEnemyMonsterName();
        battleStatus.UpdateMonsterStatus(name, status.Level, status.CurrentHP, status.HP);
    }
}
