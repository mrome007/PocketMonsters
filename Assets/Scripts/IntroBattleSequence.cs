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

    private PocketMonsterParty player;
    private PocketMonsterParty enemy;
    public void StartIntro(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        this.player = player;
        this.enemy = enemy;
        
        battleMenu.ShowMenuOption(BattleMenuOptions.TEXT, true);
        textBox.PopulateText(enemy.WildEncounter ? BattleTextType.WILDENCOUNTER : BattleTextType.TRAINERWANTSFIGHT,
            enemy.WildEncounter ? enemy.First.MonsterName : enemy.PartyTrainer.ToString() );
         
        currentIntroAnimation = enemy.WildEncounter ? wildEncounterAnimation : trainerEncounterAnimation;

        currentIntroAnimation.IntroAnimationEnded += HandleEncounterIntroAnimationEnded;
        currentIntroAnimation.PlayIntro(player, enemy);
        playerMonsterBalls.gameObject.SetActive(false);
        enemyMonsterBalls.gameObject.SetActive(false);
        playerMonsterBalls.ShowMonsterBalls(player);
        enemyMonsterBalls.ShowMonsterBalls(enemy);
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

        currentIntroAnimation.GoPlayerAnimationEnded += HandleGoPlayerAnimationEnded;
        currentIntroAnimation.GoEnemyAnimationEnded += HandleGoEnemyPlayerAnimationEnded;
        currentIntroAnimation.PlayGoPlayer();
    }

    private void HandleGoPlayerAnimationEnded()
    {
        currentIntroAnimation.GoPlayerAnimationEnded -= HandleGoPlayerAnimationEnded;
        currentIntroAnimation.PlayGoEnemy();
    }

    private void HandleGoEnemyPlayerAnimationEnded()
    {
        currentIntroAnimation.GoEnemyAnimationEnded -= HandleGoEnemyPlayerAnimationEnded;
        PostIntroBattleEnded();
    }

    private void PostIntroBattleEnded()
    {
        if(IntroBattleEnded != null)
        {
            IntroBattleEnded.Invoke();
        }
    }
}
