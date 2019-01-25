using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSequence : MonoBehaviour
{
    public event EventHandler BattleStart;
    public event EventHandler BattleEnd;

    public void StartBattleSequence()
    {
        PostBattleStart();

        //Temporary
        Invoke("EndBattleSequence", 5f);
    }

    public void EndBattleSequence()
    {
        PostBattleEnd();
    }

    public void PostBattleStart()
    {
        var handler = BattleStart;
        if(handler != null)
        {
            handler(this, null);
        }
    }

    public void PostBattleEnd()
    {
        var handler = BattleEnd;
        if(handler != null)
        {
            handler(this, null);
        }
    }
}
