using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformMonsterMoveAction
{
    #region Perform Actions

    public event  EventHandler<PerformMoveArgs> ImmediateActionsStarted;
    public event  EventHandler<PerformMoveArgs> ImmediateActionsEnded;

    public event  EventHandler<PerformMoveArgs> UpcomingActionsStarted;
    public event  EventHandler<PerformMoveArgs> UpcomingActionsEnded;

    #endregion

    private MonsterMoveAction currentMove;
    private MonsterMoveAction upcomingMove;
    private LightMonster attacker;
    private LightMonster defender;

    private PerformMoveArgs immediateActionsArgs;
    private PerformMoveArgs upcomingActionsArgs;

    public PerformMonsterMoveAction(MonsterMoveAction move, LightMonster source, LightMonster target)
    {
        Initialize(move, source, target);

        immediateActionsArgs = new PerformMoveArgs(move.MoveActionAnimation);
        upcomingActionsArgs = new PerformMoveArgs(move.MoveActionAnimation);
    }

    public void Initialize(MonsterMoveAction move, LightMonster source, LightMonster target)
    {
        currentMove = null;
        attacker = source;
        defender = target;
        upcomingMove = currentMove;
    }

    public bool CanPerformMoves()
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
