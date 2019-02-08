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

    public void StartIntro(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        introBattleAnimation.IntroAnimationEnded += HandleIntroAnimationEnded;
        introBattleAnimation.PlayIntro(enemy);
        playerMonsterBalls.gameObject.SetActive(false);
        enemyMonsterBalls.gameObject.SetActive(false);
        playerMonsterBalls.ShowMonsterBalls(player);
        enemyMonsterBalls.ShowMonsterBalls(enemy);
    }

    private void HandleIntroAnimationEnded()
    {
        introBattleAnimation.IntroAnimationEnded -= HandleIntroAnimationEnded;
        playerMonsterBalls.gameObject.SetActive(true);
        enemyMonsterBalls.gameObject.SetActive(true);

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
