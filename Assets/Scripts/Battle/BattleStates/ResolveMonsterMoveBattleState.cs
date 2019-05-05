using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will resolves the move when player selects a move.
public class ResolveMonsterMoveBattleState : BattleState
{
    [SerializeField]
    private PerformMonsterMoveAction monsterMovePerformance;

    [SerializeField]
    private BattleTextBox textBox;
    
    public override void EnterState(BattleStateArgs battleArgs)
    {
        base.EnterState(battleArgs);

        textBox.HideText();
        monsterMovePerformance.PerformMove(battleStateArgs.GetMoveSequence());
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();

        monsterMovePerformance.ImmediateActionStarted += HandleMonsterImmediateActionStarted;
        monsterMovePerformance.ImmediateActionEnded += HandleImmediateActionEnded;
    }

    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();

        monsterMovePerformance.ImmediateActionStarted -= HandleMonsterImmediateActionStarted;
        monsterMovePerformance.ImmediateActionEnded -= HandleImmediateActionEnded;
    }

    private void HandleMonsterImmediateActionStarted(object sender, PerformMoveArgs e)
    {
        
    }

    private void HandleImmediateActionEnded(object sender, PerformMoveArgs e)
    {

    }
}
