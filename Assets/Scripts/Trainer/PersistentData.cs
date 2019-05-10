using System;
using UnityEngine;

public abstract class PersistentData : MonoBehaviour
{
    public const string FolderName = "SaveData";
    public string FileName;

    public abstract void SaveData();
    public abstract void LoadData();

    public Action SaveComplete;
    public Action LoadComplete;

    private void Awake()
    {
        if(SaveGameSystem.CanSaveOrLoad())
        {
            SaveGameSystem.AddPersistentObject(this);
        }
    }

    protected void PostSaveComplete()
    {
        if(SaveComplete != null)
        {
            SaveComplete.Invoke();
        }
    }

    protected void PostLoadComplete()
    {
        if(LoadComplete != null)
        {
            LoadComplete.Invoke();
        }
    }
}
