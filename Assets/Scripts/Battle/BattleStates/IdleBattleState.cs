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

    [SerializeField]
    private PlayerPKMNBattleStatusHandler pkmnBattleStatusHandler;

    [SerializeField]
    private PlayerMonsterDetailedStatus playerMonsterStatusMenu;

    public override void EnterState(BattleStateArgs battleArgs)
    {
        base.EnterState(battleArgs);

        menu.ShowMenuOption(BattleMenuOptions.MAIN, true);
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

    public void FightPressedHandler()
    {
        movesHandler.UpdateMoveButtons(battleStateArgs.GetPlayerMonsterMoves());
        movesHandler.RegisterMoves();
    }

    public void PKMNPressedHandler()
    {
        pkmnBattleStatusHandler.UpdatePlayerMonsterStatus(battleStateArgs);
    }

    public void PokemonIconsPressedHandler(int index)
    {
        var sprite = battleStateArgs.GetMonsterSprite(index);
        var detailedStatus = battleStateArgs.GetPlayerMonsterStatusDetailed(index);
        var trainerName = battleStateArgs.PlayerTrainer.ToString();
        var monsterName = battleStateArgs.GetPlayerMonsterName(index);
        playerMonsterStatusMenu.UpdateDetailedStatus(sprite, trainerName, monsterName, detailedStatus);
    }
}
