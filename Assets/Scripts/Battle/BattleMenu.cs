using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu : MonoBehaviour 
{
    [SerializeField]
    private List<BattleOptions> menuButtons;

    public void ShowMenuOptions(bool show)
    {
        menuButtons.ForEach(option => option.BattleOptionObject.SetActive(show));
    }

    public void ShowMenuOption(BattleMenuOptions option, bool show)
    {
        ShowMenuOptions(false);
        menuButtons.ForEach(opt => opt.BattleOptionObject.SetActive(opt.OptionName == option.ToString()));
    }
}

[Serializable]
public class BattleOptions
{
    public string OptionName;
    public GameObject BattleOptionObject;
}

public enum BattleMenuOptions
{
    NONE,
    MAIN,
    TEXT,
    MOVE,
    ITEM,
    PKMN,
    STATS,
}
