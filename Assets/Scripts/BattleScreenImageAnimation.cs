using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenImageAnimation : MonoBehaviour 
{
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
}
