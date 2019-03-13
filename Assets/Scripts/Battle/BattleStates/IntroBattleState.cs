using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBattleState : BattleState 
{
    [SerializeField]
    private IntroBattleSequence introBattleSequence;

    public override void EnterState(BattleStateArgs battleArgs)
    {
        base.EnterState(battleArgs);

        introBattleSequence.StartIntro(battleArgs);
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        introBattleSequence.IntroBattleEnded += HandleIntroBattleEnded;
    }

    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        introBattleSequence.IntroBattleEnded -= HandleIntroBattleEnded;
    }

    private void HandleIntroBattleEnded()
    {
        ExitState();
    }
}
