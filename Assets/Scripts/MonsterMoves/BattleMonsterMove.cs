using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterMove
{
    public bool IsMoveDone { get; private set; }

    private List<MonsterMoveAction> moveActions;
    private int currentMoveActionIndex;

    public BattleMonsterMove()
    {
        IsMoveDone = false;
        moveActions = new List<MonsterMoveAction>();
        currentMoveActionIndex = 0;
    }

    public virtual void PerformBattleMonsterMove()
    {
    }
}
