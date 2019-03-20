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
    private const string moveTypeFormat = "TYPE/{0}";

    private void Awake()
    {
        moveButtonArgs = new IndexEventArgs(moveButtonIndex);
        moveButton = GetComponent<Button>();
        moveButton.onClick.AddListener(PostMoveButtonPressed);
    }

    private void Start()
    {

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
        moveTypeText.text = string.Format(moveTypeFormat, moveType);
        ppText.text = string.Format(ppFormat, current, pp);
    }
}
