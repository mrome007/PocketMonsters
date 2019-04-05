using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackMonsterMove : MonsterMove
{
    public override MonsterMoveAction GetMonsterMoveActions()
    {
        var normalAttackAction = MonsterMoveActions.GetMonsterMoveAction(this.GetType());
        normalAttackAction.Initialize(null, null, MonsterTarget.ENEMY, MIndex);
        return normalAttackAction;
    }
}
