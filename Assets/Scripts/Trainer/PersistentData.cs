using System;
using UnityEngine;

public abstract class PersistentData : MonoBehaviour
{
    public string FolderName;
    public string FileName;

    public abstract void SaveData();
    public abstract void LoadData();

    public Action SaveComplete;
    public Action LoadComplete;

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
