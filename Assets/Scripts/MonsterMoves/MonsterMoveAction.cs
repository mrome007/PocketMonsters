using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterMoveAction : MonoBehaviour 
{
    public abstract void Initialize(MonsterMoveInfo info);
    public abstract void ApplyMoveEffect(LightMonster target);
}
