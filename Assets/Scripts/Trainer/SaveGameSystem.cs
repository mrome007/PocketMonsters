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

        DontDestroyOnLoad(gameObject);
    }

    public static void AddPersistentObject(PersistentData data)
    {
        instance.persistentObjects.Add(data);
    }

    public static bool CanSaveOrLoad()
    {
        return instance != null;
    }

    public static void SaveGame()
    {
        if(instance.loading || instance.persistentObjects == null || instance.persistentObjects.Count <= 0)
        {
            return;
        }

        instance.saving = true;
        instance.currentIndex = 0;

        RegisterSaveData();
        instance.persistentObjects[instance.currentIndex].SaveData();
    }

    private static void RegisterSaveData()
    {
        foreach(var persistentData in instance.persistentObjects)
        {
            persistentData.SaveComplete += HandleSaveComplete;
        }
    }

    private static void UnRegisterSaveData()
    {
        foreach(var persistentData in instance.persistentObjects)
        {
            persistentData.SaveComplete -= HandleSaveComplete;
        }
    }

    private static void HandleSaveComplete()
    {
        instance.persistentObjects[instance.currentIndex++].SaveComplete -= HandleSaveComplete;

        if(instance.currentIndex < instance.persistentObjects.Count)
        {
            instance.persistentObjects[instance.currentIndex].SaveData();
        }
        else
        {
            UnRegisterSaveData();
            instance.saving = false;
            PostSaveGameComplete();
        }
    }

    private static void PostSaveGameComplete()
    {
        if(SaveGameComplete != null)
        {
            SaveGameComplete.Invoke();
        }
    }

    public static void LoadGame()
    {
        if(instance.saving || instance.persistentObjects == null || instance.persistentObjects.Count <= 0)
        {
            return;
        }

        instance.loading = true;
        instance.currentIndex = 0;

        RegisterLoadData();
        instance.persistentObjects[instance.currentIndex].LoadData();
    }

    private static void RegisterLoadData()
    {
        foreach(var persistentData in instance.persistentObjects)
        {
            persistentData.LoadComplete += HandleLoadComplete;
        }
    }

    private static void UnRegisterLoadData()
    {
        foreach(var persistentData in instance.persistentObjects)
        {
            persistentData.LoadComplete -= HandleLoadComplete;
        }
    }

    private static void HandleLoadComplete()
    {
        instance.persistentObjects[instance.currentIndex++].LoadComplete -= HandleLoadComplete;

        if(instance.currentIndex < instance.persistentObjects.Count)
        {
            instance.persistentObjects[instance.currentIndex].LoadData();
        }
        else
        {
            UnRegisterLoadData();
            instance.loading = false;
            PostLoadGameComplete();
        }
    }

    private static void PostLoadGameComplete()
    {
        if(LoadGameComplete != null)
        {
            LoadGameComplete.Invoke();
        }
    }
}
