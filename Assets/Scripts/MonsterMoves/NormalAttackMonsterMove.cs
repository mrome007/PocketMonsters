using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackMonsterMove : MonsterMove
{
    public override MonsterMoveAction GetMonsterMoveActions()
    {
        var type = typeof(DamageMonsterMoveAction);
        var normalAttackAction = MonsterMoveActions.GetMonsterMoveAction(type);
        normalAttackAction.Initialize(null, null, MonsterTarget.ENEMY, MIndex, MonsterMoveName);
        return normalAttackAction;
    }

    public override ushort GetDamage(LightMonsterStatus attacker, LightMonsterStatus defender)
    {
        var moveInfo = GetMonsterMoveCalculationInfo();
        float a = attacker.Level;
        float b = moveInfo.MoveCategory == MonsterMoveCategory.PHYSICAL ? attacker.Attack : attacker.Special;
        float c = moveInfo.Power;
        float d = moveInfo.MoveCategory == MonsterMoveCategory.PHYSICAL ? defender.Defense : defender.Special;
        float x = moveInfo.MoveType == attacker.PrimaryType || moveInfo.MoveType == attacker.SecondaryType ? 1.5f : 1f;
        float y = MonsterBattleMatchup.GetTypeMatchupDamage(moveInfo.MoveType, defender.PrimaryType, defender.SecondaryType);
        float z = UnityEngine.Random.Range(217, 256);
        var damage = (((2f * a / 5f + 2f) * c * (b / d)) / 50f + 2f) * x * y  * (z / 255f);
        return (ushort)damage;
    }
}
