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

    [SerializeField]
    private Text moveText;

    [SerializeField]
    private Text moveTypeText;

    [SerializeField]
    private Text ppText;

    private IndexEventArgs moveButtonArgs;
    private Button moveButton;
    private const string ppFormat = "{0}/{1}";
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

    public void EnableButton(bool enable)
    {
        moveButton.interactable = enable;
    }

    public void UpdateText(string moveName, string moveType, byte current, byte pp)
    {
        moveText.text = moveName;
        moveTypeText.text = moveType;
        ppText.text = string.Format(ppFormat, current, pp);
    }
}
