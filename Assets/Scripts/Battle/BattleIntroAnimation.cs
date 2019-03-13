using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleIntroAnimation : MonoBehaviour 
{
    [SerializeField]
    protected BattleScreenImageAnimation playerMonsterAnimation;
    [SerializeField]
    protected BattleScreenImageAnimation enemyMonsterAnimation;
    [SerializeField]
    protected BattleScreenImageAnimation trainerAnimation;
    [SerializeField]
    protected BattleScreenImageAnimation enemyTrainerAnimation;

    protected Animator introBattleAnimator;

    public Action IntroAnimationEnded;
    public Action GoPlayerAnimationEnded;
    public Action GoEnemyAnimationEnded;

    public abstract void PlayIntro(BattleStateArgs battleArgs);
    public abstract void PlayGoEnemy();
    public abstract void PlayGoPlayer();

    protected virtual void Awake()
    {
        introBattleAnimator = GetComponent<Animator>();
    }

    protected void PostIntroAnimationEnded()
    {
        if(IntroAnimationEnded != null)
        {
            IntroAnimationEnded.Invoke();
        }
    }

    protected void PostGoPlayerAnimationEnded()
    {
        if(GoPlayerAnimationEnded != null)
        {
            GoPlayerAnimationEnded.Invoke();
        }
    }

    protected void PostGoEnemyAnimationEnded()
    {
        if(GoEnemyAnimationEnded != null)
        {
            GoEnemyAnimationEnded.Invoke();
        }
    }
}
