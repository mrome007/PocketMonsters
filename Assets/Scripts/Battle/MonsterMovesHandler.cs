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
}
