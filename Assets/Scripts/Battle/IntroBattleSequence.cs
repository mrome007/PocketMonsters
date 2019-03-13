using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBattleSequence : MonoBehaviour
{
    [SerializeField]
    private BattleIntroAnimation wildEncounterAnimation;
    [SerializeField]
    private BattleIntroAnimation trainerEncounterAnimation;
    [SerializeField]
    private BattleMenu battleMenu;
    [SerializeField]
    private BattleTextBox textBox;
    [SerializeField]
    private BattleScreenMonsterBalls playerMonsterBalls;
    [SerializeField]
    private BattleScreenMonsterBalls enemyMonsterBalls;

    private BattleIntroAnimation currentIntroAnimation;

    public Action IntroBattleEnded;
    private BattleStateArgs bArgs;

    public void StartIntro(BattleStateArgs battleArgs)
    {        
        bArgs = battleArgs;
        battleMenu.ShowMenuOption(BattleMenuOptions.TEXT, true);
        textBox.PopulateText(bArgs.EnemyWildEncounter ? BattleTextType.WILDENCOUNTER : BattleTextType.TRAINERWANTSFIGHT,
            bArgs.EnemyWildEncounter ? bArgs.EnemyFirstMonsterName : Trainers.GetTrainerName(bArgs.EnemyTrainer));
         
        currentIntroAnimation = bArgs.EnemyWildEncounter ? wildEncounterAnimation : trainerEncounterAnimation;

        currentIntroAnimation.IntroAnimationEnded += HandleEncounterIntroAnimationEnded;
        currentIntroAnimation.PlayIntro(battleArgs);
        playerMonsterBalls.gameObject.SetActive(false);
        enemyMonsterBalls.gameObject.SetActive(false);
        playerMonsterBalls.ShowMonsterBalls(bArgs.GetCurrentMonsterBallBattleInfo(true));
        enemyMonsterBalls.ShowMonsterBalls(bArgs.GetCurrentMonsterBallBattleInfo(false));
    }

    private void HandleEncounterIntroAnimationEnded()
    {
        currentIntroAnimation.IntroAnimationEnded -= HandleEncounterIntroAnimationEnded;
        playerMonsterBalls.gameObject.SetActive(true);
        enemyMonsterBalls.gameObject.SetActive(true);

        textBox.TextActionComplete += HandleIntroTextBoxActionComplete;
        textBox.ShowText();
    }

    private void HandleIntroTextBoxActionComplete()
    {
        textBox.TextActionComplete -= HandleIntroTextBoxActionComplete;
        textBox.HideText();

        currentIntroAnimation.GoEnemyAnimationEnded += HandleGoEnemyPlayerAnimationEnded;
        currentIntroAnimation.PlayGoEnemy();
    }

    private void HandleGoPlayerAnimationEnded()
    {
        currentIntroAnimation.GoPlayerAnimationEnded -= HandleGoPlayerAnimationEnded;
        textBox.TextActionComplete += HandleGoPlayerTextBoxActionComplete;
        textBox.PopulateText(BattleTextType.GOPOKEMON, bArgs.PlayerFirstMonsterName);
        textBox.ShowText();
    }

    private void HandleGoPlayerTextBoxActionComplete()
    {
        textBox.TextActionComplete -= HandleGoPlayerTextBoxActionComplete;
        PostIntroBattleEnded();
    }

    private void HandleGoEnemyPlayerAnimationEnded()
    {
        currentIntroAnimation.GoEnemyAnimationEnded -= HandleGoEnemyPlayerAnimationEnded;

        if(bArgs.EnemyWildEncounter)
        {
            currentIntroAnimation.GoPlayerAnimationEnded += HandleGoPlayerAnimationEnded;
            currentIntroAnimation.PlayGoPlayer();
        }
        else
        {
            textBox.TextActionComplete += HandleGoEnemyTextBoxActionComplete;
            textBox.PopulateText(BattleTextType.TRAINERGOPOKEMON, Trainers.GetTrainerName(bArgs.EnemyTrainer), bArgs.EnemyFirstMonsterName);
            textBox.ShowText();
        }
    }

    private void HandleGoEnemyTextBoxActionComplete()
    {
        textBox.TextActionComplete -= HandleGoEnemyTextBoxActionComplete;

        currentIntroAnimation.GoPlayerAnimationEnded += HandleGoPlayerAnimationEnded;
        currentIntroAnimation.PlayGoPlayer();
    }

    private void PostIntroBattleEnded()
    {
        if(IntroBattleEnded != null)
        {
            IntroBattleEnded.Invoke();
        }
    }
}
