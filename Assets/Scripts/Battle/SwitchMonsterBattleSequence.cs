using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMonsterBattleSequence : MonoBehaviour 
{
    public Action SwitchMonsterComplete;
    
    [SerializeField]
    private SwitchMonsterAnimation switchAnimation;
    [SerializeField]
    private BattleMenu battleMenu;
    [SerializeField]
    private BattleTextBox textBox;
    [SerializeField]
    private MonsterBattleScreenStatus battleStatus;

    private BattleStateArgs bArgs;

    public void StartSwitchMonster(BattleStateArgs battleArgs)
    {
        bArgs = battleArgs;
        battleMenu.ShowMenuOption(BattleMenuOptions.TEXT, true);

        //TODO find a way to grab previous pokemon since the switch would have already happened.
        textBox.HideText();
        textBox.TextActionComplete += HandleCurrentSwitchActionComplete;
        textBox.ShowText();
    }

    private void HandleCurrentSwitchActionComplete()
    {
        textBox.TextActionComplete -= HandleCurrentSwitchActionComplete;
        
        switchAnimation.CurrentMonsterAnimationEnded += HandleCurrentMonsterAnimationEnded;
        switchAnimation.StartSwitchMonster(bArgs);
    }

    private void HandleCurrentMonsterAnimationEnded()
    {
        switchAnimation.CurrentMonsterAnimationEnded -= HandleCurrentMonsterAnimationEnded;

        textBox.HideText();
        textBox.TextActionComplete += HandleNewSwitchActionComplete;
        var playerBattleStatus = battleStatus.GetComponent<PlayerMonsterBattleScreenStatus>();
        var name = playerBattleStatus != null ? bArgs.GetPlayerMonsterName() : bArgs.GetEnemyMonsterName();
        textBox.PopulateText(BattleTextType.GOPOKEMON, name);
        textBox.ShowText();
    }

    private void HandleNewSwitchActionComplete()
    {
        textBox.TextActionComplete -= HandleNewSwitchActionComplete;

        textBox.HideText();
        switchAnimation.NewMonsterAnimationEnded += HandleNewMonsterAnimationEnded;
        switchAnimation.StartEndOfSwitchMonster();

        var playerBattleStatus = battleStatus.GetComponent<PlayerMonsterBattleScreenStatus>();
        var status = playerBattleStatus != null ? bArgs.GetPlayerMonsterStatus(): bArgs.GetEnemyMonsterStatus();
        var name = playerBattleStatus != null ? bArgs.GetPlayerMonsterName() : bArgs.GetEnemyMonsterName();
        battleStatus.UpdateMonsterStatus(name, status.Level, status.CurrentHP, status.HP);
    }

    private void HandleNewMonsterAnimationEnded()
    {
        switchAnimation.NewMonsterAnimationEnded -= HandleNewMonsterAnimationEnded;
        PostSwitchMonsterComplete();
    }

    private void PostSwitchMonsterComplete()
    {
        if(SwitchMonsterComplete != null)
        {
            SwitchMonsterComplete.Invoke();
        }
    }
}
