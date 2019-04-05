using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackMonsterMove : MonsterMove
{
    public override IEnumerable<MonsterMoveAction> GetMonsterMoveActions()
    {
        var normalAttackAction = MonsterMoveActions.GetMonsterMoveAction(this.GetType());
        normalAttackAction.Initialize(null, MonsterTarget.ENEMY, MIndex);
        yield return normalAttackAction;
    }
}
