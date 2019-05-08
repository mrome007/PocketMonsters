using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameSystem : MonoBehaviour 
{
    #region Instance

    private static SaveGameSystem instance;

    private static SaveGameSystem Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<SaveGameSystem>();
            }

            return instance;
        }
    }

    #endregion

    #region Events

    public static Action SaveGameComplete;
    public static Action LoadGameComplete;

    #endregion

    #region Inspector Data

    [SerializeField]
    private List<PersistentData> persistentObjects;
    
    #endregion

    #region Private members

    private int currentIndex;
    private bool saving;
    private bool loading;

    #endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = GameObject.FindObjectOfType<SaveGameSystem>();
        }
    }

    public void SaveGame()
    {
        if(loading || persistentObjects == null || persistentObjects.Count <= 0)
        {
            return;
        }

        saving = true;
        currentIndex = 0;

        RegisterSaveData();
        persistentObjects[currentIndex].SaveData();
    }

    private void RegisterSaveData()
    {
        foreach(var persistentData in persistentObjects)
        {
            persistentData.SaveComplete += HandleSaveComplete;
        }
    }

    private void UnRegisterSaveData()
    {
        foreach(var persistentData in persistentObjects)
        {
            persistentData.SaveComplete -= HandleSaveComplete;
        }
    }

    private void HandleSaveComplete()
    {
        persistentObjects[currentIndex++].SaveComplete -= HandleSaveComplete;

        if(currentIndex < persistentObjects.Count)
        {
            persistentObjects[currentIndex].SaveData();
        }
        else
        {
            UnRegisterSaveData();
            saving = false;
            PostSaveGameComplete();
        }
    }

    private void PostSaveGameComplete()
    {
        if(SaveGameComplete != null)
        {
            SaveGameComplete.Invoke();
        }
    }

    public void LoadGame()
    {
        if(saving || persistentObjects == null || persistentObjects.Count <= 0)
        {
            return;
        }

        loading = true;
        currentIndex = 0;

        RegisterLoadData();
        persistentObjects[currentIndex].LoadData();
    }

    private void RegisterLoadData()
    {
        foreach(var persistentData in persistentObjects)
        {
            persistentData.LoadComplete += HandleLoadComplete;
        }
    }

    private void UnRegisterLoadData()
    {
        foreach(var persistentData in persistentObjects)
        {
            persistentData.LoadComplete -= HandleLoadComplete;
        }
    }

    private void HandleLoadComplete()
    {
        persistentObjects[currentIndex++].LoadComplete -= HandleLoadComplete;

        if(currentIndex < persistentObjects.Count)
        {
            persistentObjects[currentIndex].LoadData();
        }
        else
        {
            UnRegisterLoadData();
            loading = false;
            PostLoadGameComplete();
        }
    }

    private void PostLoadGameComplete()
    {
        if(LoadGameComplete != null)
        {
            LoadGameComplete.Invoke();
        }
    }
}
