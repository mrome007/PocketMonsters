using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBattleState : BattleState 
{
    [SerializeField]
    private IntroBattleSequence introBattleSequence;
    [SerializeField]
    private BattleMenu battleMenu;

    public override void EnterState(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        base.EnterState(player, enemy);

        introBattleSequence.StartIntro(player, enemy);
        battleMenu.ShowMenuOption(BattleMenuOptions.TEXT, true);
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
