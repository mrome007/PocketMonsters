using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBattleState : BattleState 
{
    [SerializeField]
    private IntroBattleSequence introBattleSequence;
    [SerializeField]
    private BattleMenu battleMenu;
    [SerializeField]
    private BattleTextBox textBox;

    public override void EnterState(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        base.EnterState(player, enemy);

        introBattleSequence.StartIntro(player, enemy);
        battleMenu.ShowMenuOption(BattleMenuOptions.TEXT, true);
        textBox.PopulateText(BattleTextType.WILDENCOUNTER, enemy.First.MonsterName);
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        introBattleSequence.IntroBattleEnded += HandleIntroBattleEnded;
        textBox.TextActionComplete += HandleTextActionComplete;
    }

    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        introBattleSequence.IntroBattleEnded -= HandleIntroBattleEnded;
        textBox.TextActionComplete -= HandleTextActionComplete;
    }

    private void HandleIntroBattleEnded()
    {
        textBox.ShowText();
    }

    private void HandleTextActionComplete()
    {
        textBox.HideText();
        ExitState();
    }
}
