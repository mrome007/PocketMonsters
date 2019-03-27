using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBattleState : BattleState
{
    [SerializeField]
    private SwitchMonsterBattleSequence switchMonsterSequence;

    public override void EnterState(BattleStateArgs battleArgs)
    {
        base.EnterState(battleArgs);

        switchMonsterSequence.StartSwitchMonster(battleArgs);
    }
    
    protected override void RegisterEvents()
    {
        base.RegisterEvents();

        switchMonsterSequence.SwitchMonsterComplete += HandleSwitchMonsterComplete;
    }

    private void HandleSwitchMonsterComplete()
    {
        switchMonsterSequence.SwitchMonsterComplete -= HandleSwitchMonsterComplete;
    }
}
