﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour 
{
    [SerializeField]
    private Button newGameButton;

    [SerializeField]
    private Button loadGameButton;

    [SerializeField]
    private Button optionsButton;

    [SerializeField]
    private Button mysteryGiftButton;

    private void Start()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    private void ShowButtons()
    {
        var saveDataPath = Path.Combine(Application.persistentDataPath, "SaveData");

        loadGameButton.gameObject.SetActive(Directory.Exists(saveDataPath));
        newGameButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        mysteryGiftButton.gameObject.SetActive(false);
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BaseScene", LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        ShowButtons();
    }
}
