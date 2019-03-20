using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovesHandler : MonoBehaviour 
{
    public event EventHandler<IndexEventArgs> MoveSelected;

    [SerializeField]
    private List<BattleMoveButton> moveButtons;

    private IndexEventArgs moveSelectedArgs;

    private void Awake()
    {
        moveSelectedArgs = new IndexEventArgs();
    }

    public void RegisterMoves()
    {
        foreach(var button in moveButtons)
        {
            button.MoveButtonPressed += HandleMoveButtonPressed;
        }
    }

    public void UnRegisterMoves()
    {
        foreach(var button in moveButtons)
        {
            button.MoveButtonPressed -= HandleMoveButtonPressed;
        }
    }

    private void HandleMoveButtonPressed(object sender, IndexEventArgs e)
    {
        UnRegisterMoves();
        var handler = MoveSelected;
        if(handler != null)
        {
            moveSelectedArgs.Index = e.Index;
            handler(this, moveSelectedArgs);
        }
    }

    public void UpdateMoveButtons(MonsterMovesBundle movesBundle)
    {
        UpdateMoveButton(movesBundle.MoveOne, moveButtons[0]);
           
        UpdateMoveButton(movesBundle.MoveTwo, moveButtons[1]);

        UpdateMoveButton(movesBundle.MoveThree, moveButtons[2]);

        UpdateMoveButton(movesBundle.MoveFour, moveButtons[3]);
    }

    private void UpdateMoveButton(MonsterMoveInfo? moveInfo, BattleMoveButton button)
    {
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
