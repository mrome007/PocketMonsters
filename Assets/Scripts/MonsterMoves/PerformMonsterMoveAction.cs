using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformMonsterMoveAction
{
    #region Perform Actions

    public Action ImmediateActionsStarted;
    public Action ImmediateActionsEnded;

    public Action UpcomingActionsStarted;
    public Action UpcomingActionsEnded;

    #endregion

    private MonsterMoveAction currentMove;
    private MonsterMoveAction upcomingMove;
    private LightMonster attacker;
    private LightMonster defender;

    public PerformMonsterMoveAction(MonsterMoveAction move, LightMonster source, LightMonster target)
    {
        Initialize(move, source, target);
    }

    public void Initialize(MonsterMoveAction move, LightMonster source, LightMonster target)
    {
        currentMove = move;
        attacker = source;
        defender = target;
        upcomingMove = null;
    }

    public bool CanPerformMoves()
    {
        return currentMove != null && upcomingMove != null;
    }

    public IEnumerable<string> PerformMoves()
    {
        //TODO will step through each move action and returning the generic/specific move animation name.
        //Will use a coroutine to better time the animations.
        yield return "";
    }
}
