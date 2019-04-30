using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformMoveArgs : EventArgs
{
    public string MoveAnimationName { get; set; }

    public PerformMoveArgs(string animName)
    {
        MoveAnimationName = animName;
    }
}
