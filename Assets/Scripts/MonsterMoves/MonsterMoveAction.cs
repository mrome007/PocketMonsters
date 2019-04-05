using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterMoveAction
{
    public MonsterTarget Target { get; protected set; }
    public MonsterMoveAction NextMoveAction { get; set; }

    protected int moveIndex;
    
    public MonsterMoveAction(MonsterMoveAction next, MonsterTarget target, int index)
    {
        Initialize(next, target, index);
    }

    public virtual void Initialize(MonsterMoveAction next, MonsterTarget target, int index)
    {
        NextMoveAction = next;
        Target = target;
        moveIndex = index;
    }

    public virtual void Reset()
    {
        NextMoveAction = null;
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
