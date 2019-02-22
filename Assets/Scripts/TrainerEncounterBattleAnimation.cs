﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainerEncounterBattleAnimation : BattleIntroAnimation
{
    public override void PlayIntro(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        introBattleAnimator.Play("Play", -1, 0f);

        playerMonsterAnimation.PlayIdle(player);
        enemyMonsterAnimation.PlayIdle(enemy);
        enemyTrainerAnimation.PlayIdle(enemy);

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
