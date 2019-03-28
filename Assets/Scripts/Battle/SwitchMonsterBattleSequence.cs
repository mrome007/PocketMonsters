using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMonsterBattleSequence : MonoBehaviour 
{
    public Action SwitchMonsterComplete;
    
    [SerializeField]
    protected SwitchMonsterAnimation switchAnimation;
    [SerializeField]
    protected BattleMenu battleMenu;
    [SerializeField]
    protected BattleTextBox textBox;
    [SerializeField]
    protected MonsterBattleScreenStatus battleStatus;

    protected BattleStateArgs bArgs;

    public virtual void StartSwitchMonster(BattleStateArgs battleArgs)
    {
        bArgs = battleArgs;
        battleMenu.ShowMenuOption(BattleMenuOptions.TEXT, true);

        //TODO find a way to grab previous pokemon since the switch would have already happened.
        textBox.HideText();
        textBox.TextActionComplete += HandleCurrentSwitchActionComplete;
        textBox.ShowText();
    }

    protected virtual void HandleCurrentSwitchActionComplete()
    {
        textBox.TextActionComplete -= HandleCurrentSwitchActionComplete;
        
        switchAnimation.CurrentMonsterAnimationEnded += HandleCurrentMonsterAnimationEnded;
        switchAnimation.StartSwitchMonster(bArgs);
    }

    protected virtual void HandleCurrentMonsterAnimationEnded()
    {
        switchAnimation.CurrentMonsterAnimationEnded -= HandleCurrentMonsterAnimationEnded;

        textBox.HideText();
        textBox.TextActionComplete += HandleNewSwitchActionComplete;
        textBox.ShowText();
    }

    protected virtual void HandleNewSwitchActionComplete()
    {
        textBox.TextActionComplete -= HandleNewSwitchActionComplete;

        textBox.HideText();
        switchAnimation.NewMonsterAnimationEnded += HandleNewMonsterAnimationEnded;
        switchAnimation.StartEndOfSwitchMonster();
    }

    protected virtual void HandleNewMonsterAnimationEnded()
    {
        switchAnimation.NewMonsterAnimationEnded -= HandleNewMonsterAnimationEnded;
        PostSwitchMonsterComplete();
    }

    protected void PostSwitchMonsterComplete()
    {
        if(SwitchMonsterComplete != null)
        {
            SwitchMonsterComplete.Invoke();
        }
    }
}
