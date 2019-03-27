using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMonsterAnimation : MonoBehaviour 
{   
    [SerializeField]
    private BattleScreenImageAnimation monsterAnimation;

    public Action CurrentMonsterAnimationEnded;
    public Action NewMonsterAnimationEnded;

    private BattleStateArgs battleArgs;

    protected virtual void PostCurrentMonsterAnimationEnded()
    {
        if(CurrentMonsterAnimationEnded != null)
        {
            CurrentMonsterAnimationEnded.Invoke();
        }
    }

    protected virtual void PostNewMonsterAnimationEnded()
    {
        if(NewMonsterAnimationEnded != null)
        {
            NewMonsterAnimationEnded.Invoke();
        }
    }

    public void StartSwitchMonster(BattleStateArgs bArgs)
    {
        battleArgs = bArgs;
        monsterAnimation.ReturnComplete += HandleReturnComplete;
        monsterAnimation.PlayReturn();
    }

    private void HandleReturnComplete()
    {
        monsterAnimation.ReturnComplete -= HandleReturnComplete;
        monsterAnimation.PlayIdle(battleArgs);
        PostCurrentMonsterAnimationEnded();
    }

    public void StartEndOfSwitchMonster()
    {
        monsterAnimation.GoComplete += HandleGoComplete;
        monsterAnimation.PlayGo();
    }

    private void HandleGoComplete()
    {
        monsterAnimation.GoComplete -= HandleGoComplete;
        PostNewMonsterAnimationEnded();
    }
}
