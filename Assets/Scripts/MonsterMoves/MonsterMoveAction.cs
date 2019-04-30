using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterMoveAction
{
    public MonsterTarget Target { get; protected set; }
    public MonsterMoveAction ImmediateMoveAction { get; set; }
    public MonsterMoveAction UpcomingMoveAction { get; set; }
    public string MoveActionAnimation { get; set; }

    protected int moveIndex;
    
    public MonsterMoveAction(MonsterMoveAction next, MonsterMoveAction after, MonsterTarget target, int index, string moveAnimation)
    {
        Initialize(next, after, target, index, moveAnimation);
    }

    public virtual void Initialize(MonsterMoveAction next, MonsterMoveAction after, MonsterTarget target, int index, string moveAnimation)
    {
        ImmediateMoveAction = next;
        UpcomingMoveAction = after;
        Target = target;
        moveIndex = index;
        MoveActionAnimation = moveAnimation;
    }

    public virtual void Reset()
    {
        ImmediateMoveAction = null;
        UpcomingMoveAction = null;
        Target = MonsterTarget.ENEMY;
        moveIndex = 0;
    }

    public abstract void ApplyMoveEffect(LightMonster target);

    public virtual void ReturnMonsterMoveAction()
    {

    }
}

public enum MoveActionType
{
    NONE,
    DAMAGE
}

public enum MonsterTarget
{
    ENEMY,
    SELF
}
