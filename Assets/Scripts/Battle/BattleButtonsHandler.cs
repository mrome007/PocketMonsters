using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButtonsHandler : MonoBehaviour 
{
    public event EventHandler ButtonSelected;

    [SerializeField]
    protected List<BattleButton> buttons;

    protected EventArgs args;

    protected virtual void Awake()
    {
    }

    public void StartButtonsHandler()
    {
        RegisterButtons();
    }

    protected virtual void RegisterButtons()
    {
        foreach(var button in buttons)
        {
            button.ButtonPresssed += HandleButtonPressed;
        }
    }

    protected virtual void UnRegisterButtons()
    {
        foreach(var button in buttons)
        {
            button.ButtonPresssed -= HandleButtonPressed;
        }
    }

    protected virtual void HandleButtonPressed(object sender, EventArgs e)
    {
        UnRegisterButtons();
        var handler = ButtonSelected;
        if(handler != null)
        {
            handler(this, args);
        }
    }
}
