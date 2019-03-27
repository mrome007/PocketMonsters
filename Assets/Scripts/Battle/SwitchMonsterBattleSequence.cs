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
    private MonsterBattleScreenStatus playerBattleStatus;
    [SerializeField]
    private MonsterBattleScreenStatus enemyBattleStatus;

    private BattleStateArgs bArgs;

    public void StartSwitchMonster(BattleStateArgs battleArgs)
    {
        bArgs = battleArgs;
        battleMenu.ShowMenuOption(BattleMenuOptions.TEXT, true);

        //TODO find a way to grab previous pokemon since the switch would have already happened.
        textBox.HideText();
        textBox.TextActionComplete += HandleCurrentSwitchActionComplete;
        textBox.PopulateText(BattleTextType.SWITCH, "Current");
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
        textBox.PopulateText(BattleTextType.GOPOKEMON, bArgs.GetPlayerMonsterName());
        textBox.ShowText();
    }

    private void HandleNewSwitchActionComplete()
    {
        textBox.TextActionComplete -= HandleNewSwitchActionComplete;

        switchAnimation.NewMonsterAnimationEnded += HandleNewMonsterAnimationEnded;
        switchAnimation.StartEndOfSwitchMonster();

        var playerMonsterStatus = bArgs.GetPlayerMonsterStatus();
        var enemyMonsterStatus = bArgs.GetEnemyMonsterStatus();
        if(playerBattleStatus != null)
        {
            playerBattleStatus.UpdateMonsterStatus(bArgs.GetPlayerMonsterName(), playerMonsterStatus.Level, 
                playerMonsterStatus.CurrentHP, playerMonsterStatus.HP);
        }
        else
        {
            enemyBattleStatus.UpdateMonsterStatus(bArgs.GetEnemyMonsterName(), enemyMonsterStatus.Level, 
                enemyMonsterStatus.CurrentHP, enemyMonsterStatus.HP);
        }
    }

    private void HandleNewMonsterAnimationEnded()
    {
        switchAnimation.NewMonsterAnimationEnded -= HandleNewMonsterAnimationEnded;
    }

    private void PostSwitchMonsterComplete()
    {
        if(SwitchMonsterComplete != null)
        {
            SwitchMonsterComplete.Invoke();
        }
    }
}
