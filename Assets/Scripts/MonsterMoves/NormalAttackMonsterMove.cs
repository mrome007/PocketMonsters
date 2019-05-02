using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackMonsterMove : MonsterMove
{
    public override MonsterMoveAction GetMonsterMoveActions()
    {
        var type = typeof(DamageMonsterMoveAction);
        var normalAttackAction = MonsterMoveActions.GetMonsterMoveAction(type);
        normalAttackAction.Initialize(null, null, MonsterTarget.ENEMY, MIndex, MonsterMoveName);
        return normalAttackAction;
    }
}
