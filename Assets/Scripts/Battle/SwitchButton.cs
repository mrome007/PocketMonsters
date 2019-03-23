using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : IndexButton
{
    public int SwitchIndex
    {
        get
        {
            return index;
        }
        set
        {
            index = value;
        }
    }

    protected override void PostMenuButtonPressed()
    {
        indexArgs.Index = index;
        base.PostMenuButtonPressed();
    }
}
