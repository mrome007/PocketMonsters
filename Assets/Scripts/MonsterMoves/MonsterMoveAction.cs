using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveAction
{
    public MonsterTarget Target { get; private set; }
    public MonsterMoveAction NextMoveAction { get; set; }

    private int moveIndex;
    
    public MonsterMoveAction(MonsterMoveAction next, MonsterTarget target, int index)
    {
        NextMoveAction = next;
        Target = target;
        moveIndex = index;
    }

    public virtual void ApplyMoveEffect(LightMonster target)
    {
        var monsterMoveCalcInfo = MonsterMoves.GetMonsterMove(moveIndex).GetMonsterMoveCalculationInfo();
        Debug.Log(monsterMoveCalcInfo.MoveType + " " + monsterMoveCalcInfo.MoveCategory + " " + monsterMoveCalcInfo.Power + " " +
        monsterMoveCalcInfo.Accuracy);
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
