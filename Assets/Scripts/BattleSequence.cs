using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSequence : MonoBehaviour
{
    public event EventHandler BattleStart;
    public event EventHandler BattleEnd;

    [SerializeField]
    private BattleMenu battleMenu;
    [SerializeField]
    private BattleState initialState;

    public void StartBattleSequence(PocketMonsterParty player = null, PocketMonsterParty enemy = null)
    {
        PostBattleStart();

        initialState.EnterState(player, enemy);
    }

    public void EndBattleSequence()
    {
        battleMenu.ShowMenuOptions(false);
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
