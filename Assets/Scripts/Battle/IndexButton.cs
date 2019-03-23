using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexButton : BattleButton
{
    [SerializeField]
    protected int index;

    protected IndexEventArgs indexArgs;

    protected override void Awake()
    {
        base.Awake();
        indexArgs = new IndexEventArgs(index);
        args = indexArgs;
    }
}
