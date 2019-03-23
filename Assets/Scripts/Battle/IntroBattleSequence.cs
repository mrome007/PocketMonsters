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
    [SerializeField]
    private MonsterBattleScreenStatus playerBattleStatus;
    [SerializeField]
    private MonsterBattleScreenStatus enemyBattleStatus;

    private BattleIntroAnimation currentIntroAnimation;

    public Action IntroBattleEnded;
    private BattleStateArgs bArgs;

    public void StartIntro(BattleStateArgs battleArgs)
    {        
        bArgs = battleArgs;
        battleMenu.ShowMenuOption(BattleMenuOptions.TEXT, true);
        textBox.PopulateText(bArgs.EnemyWildEncounter ? BattleTextType.WILDENCOUNTER : BattleTextType.TRAINERWANTSFIGHT,
            bArgs.EnemyWildEncounter ? bArgs.GetEnemyMonsterName() : Trainers.GetTrainerName(bArgs.EnemyTrainer));
         
        currentIntroAnimation = bArgs.EnemyWildEncounter ? wildEncounterAnimation : trainerEncounterAnimation;

        currentIntroAnimation.IntroAnimationEnded += HandleEncounterIntroAnimationEnded;
        currentIntroAnimation.PlayIntro(battleArgs);
        playerMonsterBalls.gameObject.SetActive(false);
        enemyMonsterBalls.gameObject.SetActive(false);
        playerBattleStatus.gameObject.SetActive(false);
        enemyBattleStatus.gameObject.SetActive(false);
        playerMonsterBalls.ShowMonsterBalls(bArgs.GetCurrentMonsterBallBattleInfo(true));
        enemyMonsterBalls.ShowMonsterBalls(bArgs.GetCurrentMonsterBallBattleInfo(false));

        var playerMonsterStatus = bArgs.GetPlayerMonsterStatus();
        var enemyMonsterStatus = bArgs.GetEnemyMonsterStatus();
        playerBattleStatus.UpdateMonsterStatus(bArgs.GetPlayerMonsterName(), playerMonsterStatus.Level, 
            playerMonsterStatus.CurrentHP, playerMonsterStatus.HP);
        enemyBattleStatus.UpdateMonsterStatus(bArgs.GetEnemyMonsterName(), enemyMonsterStatus.Level,
            enemyMonsterStatus.CurrentHP, enemyMonsterStatus.HP);
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

        playerMonsterBalls.gameObject.SetActive(false);
        enemyMonsterBalls.gameObject.SetActive(false);
    }

    private void HandleGoPlayerAnimationEnded()
    {
        currentIntroAnimation.GoPlayerAnimationEnded -= HandleGoPlayerAnimationEnded;
        textBox.TextActionComplete += HandleGoPlayerTextBoxActionComplete;
        textBox.PopulateText(BattleTextType.GOPOKEMON, bArgs.GetPlayerMonsterName());
        textBox.ShowText();

        playerBattleStatus.gameObject.SetActive(true);
    }

    private void HandleGoPlayerTextBoxActionComplete()
    {
        textBox.TextActionComplete -= HandleGoPlayerTextBoxActionComplete;
        PostIntroBattleEnded();
    }

    private void HandleGoEnemyPlayerAnimationEnded()
    {
        currentIntroAnimation.GoEnemyAnimationEnded -= HandleGoEnemyPlayerAnimationEnded;
        enemyBattleStatus.gameObject.SetActive(true);
        if(bArgs.EnemyWildEncounter)
        {
            currentIntroAnimation.GoPlayerAnimationEnded += HandleGoPlayerAnimationEnded;
            currentIntroAnimation.PlayGoPlayer();
        }
        else
        {
            textBox.TextActionComplete += HandleGoEnemyTextBoxActionComplete;
            textBox.PopulateText(BattleTextType.TRAINERGOPOKEMON, Trainers.GetTrainerName(bArgs.EnemyTrainer), bArgs.GetEnemyMonsterName());
            textBox.ShowText();
        }
    }

    private void HandleGoEnemyTextBoxActionComplete()
    {
        textBox.TextActionComplete -= HandleGoEnemyTextBoxActionComplete;
        textBox.HideText();

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
