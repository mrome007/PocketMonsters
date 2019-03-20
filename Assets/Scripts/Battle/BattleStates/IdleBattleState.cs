using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBattleState : BattleState
{
    [SerializeField]
    private BattleState runNextState;
    
    [SerializeField]
    private BattleMenu menu;

    [SerializeField]
    private MonsterMovesHandler movesHandler;

    public override void EnterState(BattleStateArgs battleArgs)
    {
        base.EnterState(battleArgs);

        menu.ShowMenuOption(BattleMenuOptions.MAIN, true);

        movesHandler.UpdateMoveButtons(battleArgs.GetPlayerMonsterMoves());
        movesHandler.RegisterMoves();
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        movesHandler.MoveSelected += HandleMoveSelected;
    }

    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        movesHandler.MoveSelected -= HandleMoveSelected;
    }

    private void HandleMoveSelected(object sender, IndexEventArgs e)
    {
        //Will exit state in the future.
        Debug.Log(e.Index);
        movesHandler.MoveSelected -= HandleMoveSelected;
    }
}
