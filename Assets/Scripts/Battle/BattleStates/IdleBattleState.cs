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
    private BattleState useItemState;
    
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

    [SerializeField]
    private BattleTextBox textBox;

    public override void EnterState(BattleStateArgs battleArgs)
    {
        base.EnterState(battleArgs);

        menu.ShowMenuOption(BattleMenuOptions.MAIN, true);
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        movesHandler.StartButtonsHandler();
        monsterIconsHandler.StartButtonsHandler();

        movesHandler.ButtonSelected += HandleMoveSelected;
        monsterIconsHandler.ButtonSelected += PokemonIconsPressedHandler;
        fightButton.ButtonPresssed += HandleFightButtonPressed;
        pkmnButton.ButtonPresssed += HandlePKMNButtonPressed;

        switchButton.ButtonPresssed += PokemonSwitchPressedHandler;
    }

    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        movesHandler.StopButtonsHandler();
        monsterIconsHandler.StopButtonsHandler();

        movesHandler.ButtonSelected -= HandleMoveSelected;
        monsterIconsHandler.ButtonSelected -= PokemonIconsPressedHandler;
        fightButton.ButtonPresssed -= HandleFightButtonPressed;
        pkmnButton.ButtonPresssed -= HandlePKMNButtonPressed;

        switchButton.ButtonPresssed -= PokemonSwitchPressedHandler;
    }

    private void HandleMoveSelected(object sender, EventArgs e)
    {
        movesHandler.ButtonSelected -= HandleMoveSelected;

        var indexArgs = e as IndexEventArgs;
        if(indexArgs != null)
        {
            UnRegisterEvents();
            var move = MonsterMoves.GetMonsterMove(battleStateArgs.GetPlayerMonsterMove(0, indexArgs.Index).MonsterMoveIndex);
            textBox.PopulateText(BattleTextType.PLAYERFIGHT, battleStateArgs.GetPlayerMonsterName(), move.MonsterMoveName);
            menu.ShowMenuOption(BattleMenuOptions.TEXT, true);
            textBox.ShowText();
            textBox.TextActionComplete += HandleMoveSelectedTextBoxActionComplete;
            nextState = defaultNextState;

            battleStateArgs.SelectMove(move.GetMonsterMoveActions());
        }
    }

    private void HandleMoveSelectedTextBoxActionComplete()
    {
        textBox.TextActionComplete -= HandleMoveSelectedTextBoxActionComplete;

        ExitState();
    }

    private void HandleFightButtonPressed(object sender, EventArgs e)
    {
        movesHandler.UpdateMoveButtons(battleStateArgs.GetPlayerMonsterMoves());
    }

    private void HandlePKMNButtonPressed(object sender, EventArgs e)
    {
        pkmnBattleStatusHandler.UpdatePlayerMonsterStatus(battleStateArgs);
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
            //TODO IN ENEMY STATE, USE BattleTextType.SWITCHENEMY to populate text box
            textBox.PopulateText(BattleTextType.SWITCH, battleStateArgs.GetPlayerMonsterName());
            battleStateArgs.SwitchPlayerMonster(index);
            menu.ShowMenuOptions(false);
            nextState = switchMonsterState;
            ExitState();
        }
    }
}
