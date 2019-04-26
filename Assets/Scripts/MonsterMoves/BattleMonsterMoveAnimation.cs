using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterMoveAnimation : MonoBehaviour 
{
    public Action MonsterMoveAnimationStarted;
    public Action MonsterMoveAnimationEnded;

    private void PostMonsterMoveAnimationStarted()
    {
        if(MonsterMoveAnimationStarted != null)
        {
            MonsterMoveAnimationStarted.Invoke();
        }
    }

    private void PostMonsterMoveAnimationEnded()
    {
        if(MonsterMoveAnimationEnded != null)
        {
            MonsterMoveAnimationEnded.Invoke();
        }
    }
}
