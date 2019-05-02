using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceMonsterMoveAction
{
    private MonsterMoveAction currentMove;
    private MonsterMoveAction upcomingMove;
    private LightMonster attacker;
    private LightMonster defender;

    public SequenceMonsterMoveAction()
    {
        Initialize(null);
    }

    public SequenceMonsterMoveAction(MonsterMoveAction move)
    {
        Initialize(move);
    }

    public void Initialize(MonsterMoveAction move)
    {
        currentMove = null;
        upcomingMove = move;
    }

    public bool CanSequenceMoves()
    {
        return currentMove != null && upcomingMove != null;
    }

    public IEnumerable<string> SequenceMoves()
    {
        currentMove = upcomingMove;
        while(currentMove != null)
        {
            yield return currentMove.MoveActionAnimation;
            currentMove = currentMove.ImmediateMoveAction;
        }

        upcomingMove = upcomingMove.UpcomingMoveAction;
        yield break;
    }
}
