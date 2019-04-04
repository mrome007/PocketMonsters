using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackMonsterMove : MonsterMove
{
    public override IEnumerable<MonsterMoveAction> GetMonsterMoveActions()
    {
        yield return null;
    }
}
