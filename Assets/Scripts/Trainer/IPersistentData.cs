using System;

public interface IPersistentData
{
    string FolderName { get; }
    string FileName { get; } 
    void SaveData();
    void LoadData();

    Action SaveComplete { get; }
    Action LoadComplete { get; }
}
