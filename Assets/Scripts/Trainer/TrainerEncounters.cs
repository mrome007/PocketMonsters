using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class TrainerEncounters : MonoBehaviour, IPersistentData
{
    public string FolderName { get { return "TrainerEncounters"; } }
    public string FileName { get { return "TrainerEncounters.dat"; } }

    public Action SaveComplete { get; }
    public Action LoadComplete { get; }
    
    [SerializeField]
    private List<TrainerEncounter> trainerBattles;
    private TrainersEncounteredData encounterData =  null;

    public void SaveData()
    {
        PopulateEncounterData();

        var folderPath = Path.Combine(Application.persistentDataPath, FolderName);
        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var path = Path.Combine(folderPath, FileName);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using(FileStream fileStream = File.Open(path, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, encounterData);
        }

        var handler = SaveComplete;
        if(handler != null)
        {
            handler.Invoke();
        }
    }

    public void LoadData()
    {


        var handler = LoadComplete;
        if(handler != null)
        {
            handler.Invoke();
        }
    }

    private void PopulateEncounterData()
    {
        if(encounterData == null)
        {
            encounterData = new TrainersEncounteredData();
        }

        encounterData.Reset();
        for(int count= 0, index = 0; index < trainerBattles.Count; index++)
        {
            var mask = trainerBattles[index].Encountered ? 1 : 0;
            mask <<= count;

            if(index >= 0 && index < 32)
            {
                encounterData.FirstTrainerGroup |= mask;
            }
            else if(index >= 32 || index < 64)
            {
                encounterData.SecondTrainerGroup |= mask;
            }
            else if(index >= 64 || index < 96)
            {
                encounterData.ThirdTrainerGroup |= mask;
            }
            else if(index >= 96 || index < 128)
            {
                encounterData.FourhtTrainerGroup |= mask;
            }
            else if(index >= 128 || index < 160)
            {
                encounterData.FifthTrainerGroup |= mask;
            }
            else if(index >= 160 || index < 192)
            {
                encounterData.SixthTrainerGroup |= mask;
            }
            else if(index >= 192 || index < 224)
            {
                encounterData.SeventhTrainerGroup |= mask;
            }
            else if(index >= 224 || index < 256)
            {
                encounterData.EigthTrainerGroup |= mask;
            }
            else if(index >= 256 || index < 288)
            {
                encounterData.NinthTrainerGroup |= mask;
            }
            else if(index >= 288 || index < 320)
            {
                encounterData.TenthTrainerGroup |= mask;
            }
            else if(index >= 320 || index < 352)
            {
                encounterData.EleventhTrainerGroup |= mask;
            }
            else if(index >= 352 || index < 384)
            {
                encounterData.TwelfthTrainerGroup |= mask;
            }
            else if(index >= 384 || index < 416)
            {
                encounterData.ThirteenthTrainerGroup |= mask;
            }
            else if(index >= 416 || index < 448)
            {
                encounterData.FourteenthTrainerGroup |= mask;
            }
            else if(index >= 448 || index < 480)
            {
                encounterData.FifteenthTrainerGroup |= mask;
            }

            count++;
            count %= 32;
        }
    }
}
