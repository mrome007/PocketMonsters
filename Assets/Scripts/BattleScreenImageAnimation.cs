using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenImageAnimation : MonoBehaviour 
{
    public Action IntoViewComplete;
    public Action GoComplete;
    public Action ReturnComplete;
    
    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void PlayIdle()
    {
        animator.Play("Idle", -1, 0f);
    }

    public virtual void PlayBattle()
    {
        animator.Play("Battle", -1, 0f);
    }

    public virtual void PlayToView(PocketMonsterParty party)
    {
        animator.Play("View", -1, 0f);
    }

    public virtual void PlayGo()
    {
        animator.Play("Go", -1, 0f);
    }

    public virtual void PlayReturn()
    {
        animator.Play("Return", -1, 0f);
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
