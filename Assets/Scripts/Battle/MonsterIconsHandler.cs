using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIconsHandler : BattleButtonsHandler
{
    [SerializeField]
    private SwitchButton switchButton;

    private IndexEventArgs monsterIconArgs;

    protected override void Awake()
    {
        base.Awake();
        monsterIconArgs = new IndexEventArgs();
    }

    protected override void HandleButtonPressed(object sender, EventArgs e)
    {
        var indexArgs = e as IndexEventArgs;
        monsterIconArgs.Index = indexArgs != null ? indexArgs.Index : 0;
        switchButton.SwitchIndex = monsterIconArgs.Index;
        args = monsterIconArgs;
        base.HandleButtonPressed(sender, e);
    }
}
