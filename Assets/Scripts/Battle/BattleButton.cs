using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BattleButton : MonoBehaviour 
{
    public event EventHandler ButtonPresssed;
    protected Button button;
    protected EventArgs args;

    protected virtual void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PostMenuButtonPressed);
    }

    protected virtual void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    public virtual void EnableButton(bool enable)
    {
        button.interactable = enable;
    }

    protected virtual void PostMenuButtonPressed()
    {
        var handler = ButtonPresssed;
        if(handler != null)
        {
            handler(this, args);
        }
    }
}
