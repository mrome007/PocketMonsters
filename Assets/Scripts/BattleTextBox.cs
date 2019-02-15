using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleTextBox : MonoBehaviour, IPointerDownHandler
{
    public Action TextActionComplete;
    
    [SerializeField]
    private GameObject touchIconObject;

    [SerializeField]
    private Text textBoxText;

    private Dictionary<BattleTextType, string> battleTexts = new Dictionary<BattleTextType, string>()
    {
        { BattleTextType.WILDENCOUNTER, "Wild {0} appeared!" },
        { BattleTextType.GOPOKEMON, "Go {0}! {1}!" }
    };

    private StringBuilder textContainer;
    private string textFormat;
    private bool TextDone = false;

    private void Awake()
    {
        textContainer = new StringBuilder(32);
    }

    public void PopulateText(BattleTextType textType, params string [] args)
    {
        textFormat = string.Format(battleTexts[textType], args);
    }

    public void ShowText()
    {
        TextDone = false;
        textContainer.Length = 0;
        touchIconObject.SetActive(true);
        textContainer.Append(textFormat);
        textBoxText.gameObject.SetActive(true);
        textBoxText.text = textContainer.ToString();
        TextDone = true;
    }

    public void HideText()
    {
        TextDone = false;
        touchIconObject.SetActive(false);
        textBoxText.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(TextDone)
        {
            PostTextActionComplete();
        }
        else
        {
            HideText();
        }
    }

    private void PostTextActionComplete()
    {
        if(TextActionComplete != null)
        {
            TextActionComplete.Invoke();
        }
    }
}

public enum BattleTextType
{
    NONE,
    WILDENCOUNTER,
    GOPOKEMON,
    MOVEUSED,
}
