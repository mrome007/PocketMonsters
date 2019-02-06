using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBattleSequence : MonoBehaviour
{
    [SerializeField]
    private IntroBattleAnimation introBattleAnimation;
    [SerializeField]
    private BattleScreenMonsterBalls playerMonsterBalls;
    [SerializeField]
    private BattleScreenMonsterBalls enemyMonsterBalls;

    public Action IntroBattleEnded;

    private PocketMonsterParty player;
    private PocketMonsterParty enemy;

    public void StartIntro(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        this.player = player;
        this.enemy = enemy;
        introBattleAnimation.IntroAnimationEnded += HandleIntroAnimationEnded;
        introBattleAnimation.PlayIntro();
        playerMonsterBalls.gameObject.SetActive(false);
        enemyMonsterBalls.gameObject.SetActive(false);
    }

    private void HandleIntroAnimationEnded()
    {
        introBattleAnimation.IntroAnimationEnded -= HandleIntroAnimationEnded;
        playerMonsterBalls.gameObject.SetActive(true);
        enemyMonsterBalls.gameObject.SetActive(!enemy.WildEncounter);
    }
}
