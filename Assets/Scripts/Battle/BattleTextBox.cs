using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleTextBox : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action TextActionComplete;
    
    [SerializeField]
    private GameObject touchIconObject;

    [SerializeField]
    private Text textBoxText;

    [SerializeField]
    private float textFastFillSpeed;
    [SerializeField]
    private float textNormalFillSpeed;

    private float textFillSpeed;
    private bool textFillActive;
    private float textFillTimer;
    private float textFillTime = 0.25f;

    private Dictionary<BattleTextType, string> battleTexts = new Dictionary<BattleTextType, string>()
    {
        { BattleTextType.WILDENCOUNTER, "Wild {0} appeared!" },
        { BattleTextType.GOPOKEMON, "Go! {0}!" },
        { BattleTextType.TRAINERWANTSFIGHT, "{0} wants to fight!" },
        { BattleTextType.TRAINERGOPOKEMON, "{0} sent out {1}!" },
        { BattleTextType.SWITCH, "{0} enough! Come back!" },
        { BattleTextType.SWITCHENEMY, "{0} withdrew {1}!" },
        { BattleTextType.PLAYERFIGHT, "{0} used {1}!" },
        { BattleTextType.ENEMYFIGHT, "Enemy {0} used {1}!" }
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
        textBoxText.text = string.Empty;
        textBoxText.gameObject.SetActive(true);
        textFillSpeed = textNormalFillSpeed;
        StartCoroutine(FillCharacters());
    }

    private IEnumerator FillCharacters()
    {
        textFillActive = true;
        var currentIndex = 0;
        textFillTimer = textFillTime;
        while(textContainer.Length < textFormat.Length)
        {
            yield return null;
            if(textFillTimer < 0f)
            {
                textContainer.Append(textFormat[currentIndex]);
                textBoxText.text = textContainer.ToString();
                currentIndex++;
                textFillTimer = textFillTime;
            }
            textFillTimer -= textFillSpeed * Time.deltaTime;
        }
        TextDone = true;
        textFillActive = false;
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
            TextDone = false;
            PostTextActionComplete();
        }

        if(textFillActive)
        {
            textFillSpeed = textFastFillSpeed;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(textFillActive)
        {
            textFillSpeed = textNormalFillSpeed;
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
    TRAINERWANTSFIGHT,
    GOPOKEMON,
    TRAINERGOPOKEMON,
    MOVEUSED,
    SWITCH,
    SWITCHENEMY,
    PLAYERFIGHT,
    ENEMYFIGHT
}
