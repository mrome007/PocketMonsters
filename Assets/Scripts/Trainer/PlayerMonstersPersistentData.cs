using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerMonstersPersistentData : PersistentData
{
    private TrainerEncounter trainerEncounter;

    private void Awake()
    {
        trainerEncounter = GetComponent<TrainerEncounter>();
    }

    public override void SaveData()
    {
        var folderPath = Path.Combine(Application.persistentDataPath, FolderName);
        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var path = Path.Combine(folderPath, FileName);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using(FileStream fileStream = File.Open(path, FileMode.OpenOrCreate))
        {
            for(var count = 0; count < PocketMonsterParty.MAX_MONSTERS_IN_PARTY; count++)
            {
                binaryFormatter.Serialize(fileStream, trainerEncounter.MonstersParty[count]);
            }
        }

        PostSaveComplete();
    }

    public override void LoadData()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        var folderPath = Path.Combine(Application.persistentDataPath, FolderName);
        var path = Path.Combine(folderPath, FileName);
        using(FileStream fileStream = File.Open(path, FileMode.Open))
        {
            for(var count = 0; count < PocketMonsterParty.MAX_MONSTERS_IN_PARTY; count++)
            {
                var monsterInfo = (PartyMonsterInfo)binaryFormatter.Deserialize(fileStream);
                trainerEncounter.MonstersParty.AddMonsterToParty(count, monsterInfo);
            }
        }
        PostLoadComplete();
    }
}
