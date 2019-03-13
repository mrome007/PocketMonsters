using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildEncounterBattleAnimation : BattleIntroAnimation
{
    public override void PlayIntro(BattleStateArgs battleArgs)
    {
        introBattleAnimator.Play("Play", -1, 0f);

        playerMonsterAnimation.PlayIdle(battleArgs);
        enemyMonsterAnimation.PlayIdle(battleArgs);

        enemyMonsterAnimation.PlayToView();
        trainerAnimation.PlayToView();
    }

    public override void PlayGoPlayer()
    {
        trainerAnimation.ReturnComplete += HandleWildEncounterPlayerReturnComplete;
        trainerAnimation.PlayReturn(); 
    }

    public override void PlayGoEnemy()
    {
        PostGoEnemyAnimationEnded();
    }

    private void HandleWildEncounterPlayerReturnComplete()
    {
        trainerAnimation.ReturnComplete -= HandleWildEncounterPlayerReturnComplete;
        playerMonsterAnimation.GoComplete += HandleGoWildEncounterComplete;
        playerMonsterAnimation.PlayGo();
    }

    private void HandleGoWildEncounterComplete()
    {
        playerMonsterAnimation.GoComplete -= HandleGoWildEncounterComplete;
        PostGoPlayerAnimationEnded();
    }
}
