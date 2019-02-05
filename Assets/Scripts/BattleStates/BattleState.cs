using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : MonoBehaviour 
{
    public virtual void EnterState()
    {
        RegisterEvents();
    }

    public virtual void ExitState()
    {
        UnRegisterEvents();
    }
    
    protected virtual void RegisterEvents()
    {
    }

    protected virtual void UnRegisterEvents()
    {
    }
}
