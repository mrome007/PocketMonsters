using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMoveButton : MonoBehaviour 
{
    public event EventHandler<IndexEventArgs> MoveButtonPressed;

    [SerializeField]
    private int moveButtonIndex;

    private IndexEventArgs moveButtonArgs;
    private Button moveButton;

    private void Awake()
    {
        moveButtonArgs = new IndexEventArgs(moveButtonIndex);
        moveButton = GetComponent<Button>();
        moveButton.onClick.AddListener(PostMoveButtonPressed);
    }

    private void PostMoveButtonPressed()
    {
        var handler = MoveButtonPressed;
        if(handler != null)
        {
            handler(this, moveButtonArgs);
        }
    }
}
