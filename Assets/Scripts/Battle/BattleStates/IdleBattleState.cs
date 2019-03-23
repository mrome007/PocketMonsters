using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBattleState : BattleState
{
    [SerializeField]
    private BattleState runNextState;

    [SerializeField]
    private BattleState switchMonsterState;

    [SerializeField]
    private BattleState performBattleState;
    
    [SerializeField]
    private BattleMenu menu;

    [SerializeField]
    private MonsterMovesHandler movesHandler;

    [SerializeField]
    private PlayerPKMNBattleStatusHandler pkmnBattleStatusHandler;

    [SerializeField]
    private PlayerMonsterDetailedStatus playerMonsterStatusMenu;

    [SerializeField]
    private BattleButton fightButton;
    [SerializeField]
    private BattleButton pkmnButton;
    [SerializeField]
    private BattleButton itemButton;
    [SerializeField]
    private BattleButton runButton;

    public override void EnterState(BattleStateArgs battleArgs)
    {
        base.EnterState(battleArgs);

        menu.ShowMenuOption(BattleMenuOptions.MAIN, true);
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        movesHandler.ButtonSelected += HandleMoveSelected;
        fightButton.ButtonPresssed += HandleFightButtonPressed;
        pkmnButton.ButtonPresssed += HandlePKMNButtonPressed;
    }

    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        movesHandler.ButtonSelected -= HandleMoveSelected;
        fightButton.ButtonPresssed -= HandleFightButtonPressed;
        pkmnButton.ButtonPresssed -= HandlePKMNButtonPressed;
    }

    private void HandleMoveSelected(object sender, EventArgs e)
    {
        //Will exit state in the future.
        Debug.Log("Move Selected");
        movesHandler.ButtonSelected -= HandleMoveSelected;
    }

    private void HandleFightButtonPressed(object sender, EventArgs e)
    {
        movesHandler.UpdateMoveButtons(battleStateArgs.GetPlayerMonsterMoves());
        movesHandler.StartButtonsHandler();
    }

    private void HandlePKMNButtonPressed(object sender, EventArgs e)
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

    public void PokemonSwitchPressedHandler(int index)
    {
        if(index == 0)
        {
            menu.ShowMenuOption(BattleMenuOptions.MAIN, true);
        }
        else
        {
            menu.ShowMenuOptions(false);
            nextState = switchMonsterState;
            ExitState();
        }
    }
}
