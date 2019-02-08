using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBattleAnimation : MonoBehaviour
{
    public Action IntroAnimationEnded;

    [SerializeField]
    private SpriteRenderer enemySpriteRenderer;
    [SerializeField]
    private BattleScreenIntroEnemyImage enemyImage;

    private Animator introBattleAnimator;

    private void Awake()
    {
        introBattleAnimator = GetComponent<Animator>();
    }

    public void PlayIntro(PocketMonsterParty enemy)
    {
        enemySpriteRenderer.sprite = enemyImage.GetEnemySprite(enemy);
        introBattleAnimator.Play("Play", -1, 0f);
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
}
