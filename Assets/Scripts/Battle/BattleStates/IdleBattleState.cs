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
    private BattleMenu menu;

    [SerializeField]
    private MonsterMovesHandler movesHandler;

    [SerializeField]
    private MonsterIconsHandler monsterIconsHandler;

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

    [SerializeField]
    private BattleButton switchButton;

    public override void EnterState(BattleStateArgs battleArgs)
    {
        base.EnterState(battleArgs);

        menu.ShowMenuOption(BattleMenuOptions.MAIN, true);
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        movesHandler.ButtonSelected += HandleMoveSelected;
        monsterIconsHandler.ButtonSelected += PokemonIconsPressedHandler;
        fightButton.ButtonPresssed += HandleFightButtonPressed;
        pkmnButton.ButtonPresssed += HandlePKMNButtonPressed;

        switchButton.ButtonPresssed += PokemonSwitchPressedHandler;
    }

    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        movesHandler.ButtonSelected -= HandleMoveSelected;
        monsterIconsHandler.ButtonSelected -= PokemonIconsPressedHandler;
        fightButton.ButtonPresssed -= HandleFightButtonPressed;
        pkmnButton.ButtonPresssed -= HandlePKMNButtonPressed;

        switchButton.ButtonPresssed -= PokemonSwitchPressedHandler;
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
        monsterIconsHandler.StartButtonsHandler();
    }

    private void PokemonIconsPressedHandler(object sender, EventArgs e)
    {
        var indexArgs = e as IndexEventArgs;
        var index = indexArgs != null ? indexArgs.Index : 0;
        var sprite = battleStateArgs.GetMonsterSprite(index);
        var detailedStatus = battleStateArgs.GetPlayerMonsterStatusDetailed(index);
        var trainerName = battleStateArgs.PlayerTrainer.ToString();
        var monsterName = battleStateArgs.GetPlayerMonsterName(index);
        playerMonsterStatusMenu.UpdateDetailedStatus(sprite, trainerName, monsterName, detailedStatus);
    }

    private void PokemonSwitchPressedHandler(object sender, EventArgs e)
    {
        var indexArgs = e as IndexEventArgs;
        var index = indexArgs != null ? indexArgs.Index : 0;
        if(index == 0)
        {
            menu.ShowMenuOption(BattleMenuOptions.MAIN, true);
        }
        else
        {
            battleStateArgs.SwitchPlayerMonster(index);
            menu.ShowMenuOptions(false);
            nextState = switchMonsterState;
            ExitState();
        }
    }
}
