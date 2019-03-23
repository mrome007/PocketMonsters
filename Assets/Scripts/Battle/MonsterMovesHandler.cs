using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovesHandler : BattleButtonsHandler
{
    private IndexEventArgs moveSelectedArgs;

    protected override void Awake()
    {
        base.Awake();
        moveSelectedArgs = new IndexEventArgs();
    }

    protected override void HandleButtonPressed(object sender, EventArgs e)
    {
        var indexArgs = e as IndexEventArgs;
        moveSelectedArgs.Index = indexArgs != null ? indexArgs.Index : 0;
        args = moveSelectedArgs;
        base.HandleButtonPressed(sender, e);
    }

    public void UpdateMoveButtons(MonsterMovesBundle movesBundle)
    {
        UpdateMoveButton(movesBundle.MoveOne, buttons[0] as BattleMoveButton);
        UpdateMoveButton(movesBundle.MoveTwo, buttons[1] as BattleMoveButton);
        UpdateMoveButton(movesBundle.MoveThree, buttons[2] as BattleMoveButton);
        UpdateMoveButton(movesBundle.MoveFour, buttons[3] as BattleMoveButton);
    }

    private void UpdateMoveButton(MonsterMoveInfo? moveInfo, BattleMoveButton button)
    {
        button.EnableButton(moveInfo.HasValue);
        if(!moveInfo.HasValue)
        {
            button.UpdateText(string.Empty, string.Empty, 0, 0);
        }
        else
        {
            var name = MonsterMoves.GetMonsterMove(moveInfo.Value.MonsterMoveIndex).MonsterMoveName;
            button.UpdateText(name, moveInfo.Value.MoveType.ToString(), moveInfo.Value.CurrentPP, moveInfo.Value.PP);
        }
    }
}
