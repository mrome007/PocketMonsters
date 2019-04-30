using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMonsterMoveAction : MonsterMoveAction
{
    public DamageMonsterMoveAction(MonsterMoveAction next, MonsterMoveAction after, MonsterTarget target, int index, string moveAnimation) 
        : base(next, after, target, index, moveAnimation)
    {
    }

    public override void ApplyMoveEffect(LightMonster target)
    {
        Debug.Log("Damage Action");
    }
}
