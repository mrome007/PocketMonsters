using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMoveButton : IndexButton
{
    [SerializeField]
    private Text moveText;

    [SerializeField]
    private Text moveTypeText;

    [SerializeField]
    private Text ppText;

    private IndexEventArgs moveButtonArgs;
    private const string ppFormat = "{0}/{1}";
    private const string moveTypeFormat = "TYPE/{0}";

    public void UpdateText(string moveName, string moveType, byte current, byte pp)
    {        
        moveText.text = moveName;
        moveTypeText.text = string.Format(moveTypeFormat, moveType);
        ppText.text = string.Format(ppFormat, current, pp);
    }
}
