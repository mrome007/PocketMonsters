using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBattleAnimation : MonoBehaviour
{
    [SerializeField]
    private BattleScreenImageAnimation playerMonsterAnimation;
    [SerializeField]
    private BattleScreenImageAnimation enemyMonsterAnimation;
    [SerializeField]
    private BattleScreenImageAnimation trainerAnimation;
    [SerializeField]
    private BattleScreenImageAnimation enemyTrainerAnimation;
    
    public Action IntroAnimationEnded;
    public Action GoWildEncounterEnded;
    private Animator introBattleAnimator;

    private void Awake()
    {
        introBattleAnimator = GetComponent<Animator>();
    }

    public void PlayIntro(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        if(enemy.WildEncounter)
        {
            PlayIntroWildEncounter(player, enemy);
        }
        else
        {
            PlayIntroTrainerEncounter(player, enemy);
        }
    }

    private void PlayIntroWildEncounter(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        introBattleAnimator.Play("Play", -1, 0f);

        playerMonsterAnimation.PlayIdle(player);
        enemyMonsterAnimation.PlayIdle(enemy);

        enemyMonsterAnimation.PlayToView();
        trainerAnimation.PlayToView();
    }

    public void GoWildEncounter()
    {
        trainerAnimation.ReturnComplete += HandleWildEncounterPlayerReturnComplete;
        trainerAnimation.PlayReturn();
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
        PostGoWildEncounterEnd();
    }

    private void PlayIntroTrainerEncounter(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        introBattleAnimator.Play("Play", -1, 0f);

        enemyTrainerAnimation.PlayIdle(enemy);

        enemyTrainerAnimation.PlayToView();
        trainerAnimation.PlayToView();
    }

    public void StopIntro()
    {
        introBattleAnimator.Play("Idle", -1, 0f);
    }

    private void PostIntroAnimationEnd()
    {
        if(IntroAnimationEnded != null)
        {
            IntroAnimationEnded.Invoke();
        }
    }

    private void PostGoWildEncounterEnd()
    {
        if(GoWildEncounterEnded != null)
        {
            GoWildEncounterEnded.Invoke();
        }
    }
}
