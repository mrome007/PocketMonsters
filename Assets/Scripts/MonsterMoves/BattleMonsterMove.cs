using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterMove
{
    public bool IsMoveDone { get; private set; }

    private int currentMoveActionIndex;

    public BattleMonsterMove()
    {
        IsMoveDone = false;
        currentMoveActionIndex = 0;
    }
}
