using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : MonoBehaviour 
{
    [SerializeField]
    protected BattleState defaultNextState;

    protected BattleState nextState;

    protected BattleStateArgs battleStateArgs;

    public virtual void EnterState(BattleStateArgs battleArgs)
    {
        battleStateArgs = battleArgs;
        nextState = defaultNextState;
        RegisterEvents();
    }

    public virtual void ExitState()
    {
        UnRegisterEvents();

        nextState.EnterState(battleStateArgs);
    }
    
    protected virtual void RegisterEvents()
    {
    }

    protected virtual void UnRegisterEvents()
    {
    }
}
