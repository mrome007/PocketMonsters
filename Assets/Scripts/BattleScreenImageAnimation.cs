using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenImageAnimation : MonoBehaviour 
{
    public Action IntoViewComplete;
    public Action GoComplete;
    public Action ReturnComplete;
    
    protected Animator screenImageAnimator;

    protected virtual void Awake()
    {
        screenImageAnimator = GetComponent<Animator>();
    }

    public virtual void PlayIdle(PocketMonsterParty party)
    {
        screenImageAnimator.Play("Idle", -1, 0f);
    }

    public virtual void PlayBattle()
    {
        screenImageAnimator.Play("Battle", -1, 0f);
    }

    public virtual void PlayToView()
    {
        screenImageAnimator.Play("View", -1, 0f);
    }

    public virtual void PlayGo()
    {
        screenImageAnimator.Play("Go", -1, 0f);
    }

    public virtual void PlayReturn()
    {
        screenImageAnimator.Play("Return", -1, 0f);
    }

    protected void PostIntoViewComplete()
    {
        if(IntoViewComplete != null)
        {
            IntoViewComplete.Invoke();
        }
    }

    protected void PostGoComplete()
    {
        if(GoComplete != null)
        {
            GoComplete.Invoke();
        }
    }

    protected void PostReturnComplete()
    {
        if(ReturnComplete != null)
        {
            ReturnComplete.Invoke();
        }
    }
}
