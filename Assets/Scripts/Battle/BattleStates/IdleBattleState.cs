using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBattleState : BattleState
{
    [SerializeField]
    private BattleMenu menu;

    public override void EnterState(BattleStateArgs battleArgs)
    {
        base.EnterState(battleArgs);

        menu.ShowMenuOption(BattleMenuOptions.MAIN, true);
    }
}
