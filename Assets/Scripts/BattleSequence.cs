using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSequence : MonoBehaviour
{
    public event EventHandler BattleStart;
    public event EventHandler BattleEnd;

    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
    [SerializeField]
    private SpriteRenderer enemySpriteRenderer;

    public void StartBattleSequence(PocketMonsterParty player = null, PocketMonsterParty enemy = null)
    {
        PostBattleStart();

        playerSpriteRenderer.sprite = player.GetCurrentMonster().Back;
        enemySpriteRenderer.sprite = enemy.GetCurrentMonster().Front;
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
