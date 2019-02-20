using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBattleSequence : MonoBehaviour
{
    [SerializeField]
    private IntroBattleAnimation introBattleAnimation;
    [SerializeField]
    private BattleMenu battleMenu;
    [SerializeField]
    private BattleTextBox textBox;
    [SerializeField]
    private BattleScreenMonsterBalls playerMonsterBalls;
    [SerializeField]
    private BattleScreenMonsterBalls enemyMonsterBalls;

    public Action IntroBattleEnded;

    public void StartIntro(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        battleMenu.ShowMenuOption(BattleMenuOptions.TEXT, true);
        textBox.PopulateText(enemy.WildEncounter ? BattleTextType.WILDENCOUNTER : BattleTextType.TRAINERWANTSFIGHT,
            enemy.WildEncounter ? enemy.First.MonsterName : enemy.PartyTrainer.ToString() );
         
        if(enemy.WildEncounter)
        {
            introBattleAnimation.IntroAnimationEnded += HandleIntroWildEncounterAnimationEnded;
        }
        introBattleAnimation.PlayIntro(player, enemy);
        playerMonsterBalls.gameObject.SetActive(false);
        enemyMonsterBalls.gameObject.SetActive(false);
        playerMonsterBalls.ShowMonsterBalls(player);
        enemyMonsterBalls.ShowMonsterBalls(enemy);
    }

    private void HandleIntroWildEncounterAnimationEnded()
    {
        introBattleAnimation.IntroAnimationEnded -= HandleIntroWildEncounterAnimationEnded;
        playerMonsterBalls.gameObject.SetActive(true);
        enemyMonsterBalls.gameObject.SetActive(true);

        textBox.TextActionComplete += HandleIntroWildEncounterTextBoxActionComplete;
        textBox.ShowText();
    }

    private void HandleIntroWildEncounterTextBoxActionComplete()
    {
        textBox.TextActionComplete -= HandleIntroWildEncounterTextBoxActionComplete;
        textBox.HideText();

        introBattleAnimation.GoWildEncounterEnded += HandleGoWildEncounterEnded;
        introBattleAnimation.GoWildEncounter();
    }

    private void HandleGoWildEncounterEnded()
    {
        introBattleAnimation.GoWildEncounterEnded -= HandleGoWildEncounterEnded;

    }

    private void PostIntroBattleEnded()
    {
        if(IntroBattleEnded != null)
        {
            IntroBattleEnded.Invoke();
        }
    }
}
