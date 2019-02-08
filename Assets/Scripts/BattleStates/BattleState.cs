using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : MonoBehaviour 
{
    [SerializeField]
    protected BattleState defaultNextState;

    protected BattleState nextState;

    protected PocketMonsterParty player;
    protected PocketMonsterParty enemy;

    public virtual void EnterState(PocketMonsterParty player, PocketMonsterParty enemy)
    {
        this.player = player;
        this.enemy = enemy;
        nextState = defaultNextState;
        RegisterEvents();
    }

    public virtual void ExitState()
    {
        UnRegisterEvents();

        if(nextState != null)
        {
            nextState.EnterState(this.player, this.enemy);
        }
    }
    
    protected virtual void RegisterEvents()
    {
    }

    protected virtual void UnRegisterEvents()
    {
    }
}
