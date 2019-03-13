using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainerEncounterBattleAnimation : BattleIntroAnimation
{
    public override void PlayIntro(BattleStateArgs battleArgs)
    {
        introBattleAnimator.Play("Play", -1, 0f);

        playerMonsterAnimation.PlayIdle(battleArgs);
        enemyMonsterAnimation.PlayIdle(battleArgs);
        enemyTrainerAnimation.PlayIdle(battleArgs);

        enemyTrainerAnimation.PlayToView();
        trainerAnimation.PlayToView();
    }

    public override void PlayGoEnemy()
    {
        enemyTrainerAnimation.ReturnComplete += HandleTrainerEncounterEnemyReturnComplete;
        enemyTrainerAnimation.PlayReturn();
    }

    public override void PlayGoPlayer()
    {
        trainerAnimation.ReturnComplete += HandleTrainerEncounterPlayerReturnComplete;
        trainerAnimation.PlayReturn();
    }

    private void HandleTrainerEncounterPlayerReturnComplete()
    {
        trainerAnimation.ReturnComplete -= HandleTrainerEncounterPlayerReturnComplete;
        playerMonsterAnimation.GoComplete += HandleTrainerEncounterPlayerMonsterGoComplete;
        playerMonsterAnimation.PlayGo();
    }

    private void HandleTrainerEncounterPlayerMonsterGoComplete()
    {
        playerMonsterAnimation.GoComplete -= HandleTrainerEncounterPlayerMonsterGoComplete;
        PostGoPlayerAnimationEnded();
    }

    private void HandleTrainerEncounterEnemyReturnComplete()
    {
        enemyTrainerAnimation.ReturnComplete -= HandleTrainerEncounterEnemyReturnComplete;
        enemyMonsterAnimation.GoComplete += HandleTrainerEncounterEnemyMonsterGoComplete;
        enemyMonsterAnimation.PlayGo();
    }

    private void HandleTrainerEncounterEnemyMonsterGoComplete()
    {
        enemyMonsterAnimation.GoComplete -= HandleTrainerEncounterEnemyMonsterGoComplete;
        PostGoEnemyAnimationEnded();
    }
}
