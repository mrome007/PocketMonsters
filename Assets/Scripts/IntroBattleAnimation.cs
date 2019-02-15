using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBattleAnimation : MonoBehaviour
{
    public Action IntroAnimationEnded;
    private Animator introBattleAnimator;

    private void Awake()
    {
        introBattleAnimator = GetComponent<Animator>();
    }

    public void PlayIntro(PocketMonsterParty enemy)
    {
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
