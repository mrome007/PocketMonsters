using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackMonsterMove : MonsterMove
{
    public override List<MonsterMoveAction> GetMonsterMoveActions()
    {
        var moveActions = new List<MonsterMoveAction>();

        var attackAction = new MonsterMoveAction(null, MonsterTarget.ENEMY, MIndex);
        moveActions.Add(attackAction);

        return moveActions;
    }
}
