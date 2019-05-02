using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
