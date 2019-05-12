using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour 
{
    private Button newGameButton;

    private void Awake()
    {
        newGameButton = GetComponent<Button>();
        newGameButton.onClick.AddListener(HandleNewGame);
    }

    private void HandleNewGame()
    {
        PocketMonsterElementController.ShowPocketMonsterElement("Base", true);
    }
}
