using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour 
{
    private Button loadButton;

    private void Awake()
    {
        loadButton = GetComponent<Button>();

        if(SaveGameSystem.CanSaveOrLoad())
        {
            SaveGameSystem.LoadGameComplete += HandleLoadGameComplete;
            loadButton.onClick.AddListener(HandleLoadGame);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if(loadButton != null)
        {
            loadButton.onClick.RemoveAllListeners();
        }

        SaveGameSystem.LoadGameComplete -= HandleLoadGameComplete;
    }

    private void HandleLoadGame()
    {
        loadButton.interactable = false;
        SaveGameSystem.LoadGame();
    }

    private void HandleLoadGameComplete()
    {
        PocketMonsterElementController.ShowPocketMonsterElement("Base", true);
        loadButton.interactable = true;
    }
}
