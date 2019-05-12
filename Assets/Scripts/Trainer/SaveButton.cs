using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour 
{
    private Button saveButton;

    [SerializeField]
    private Button returnButton;

    private void Awake()
    {
        saveButton = GetComponent<Button>();

        if(SaveGameSystem.CanSaveOrLoad())
        {
            SaveGameSystem.SaveGameComplete += HandleSaveGameComplete;
            saveButton.onClick.AddListener(HandleSaveGame);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if(saveButton != null)
        {
            saveButton.onClick.RemoveAllListeners();
        }

        SaveGameSystem.SaveGameComplete -= HandleSaveGameComplete;
    }

    private void HandleSaveGame()
    {
        saveButton.interactable = false;
        SaveGameSystem.SaveGame();
    }

    private void HandleSaveGameComplete()
    {
        saveButton.interactable = true;
        returnButton.onClick.Invoke();
    }
}
