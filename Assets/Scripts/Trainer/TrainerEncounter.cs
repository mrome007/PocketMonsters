using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TrainerEncounter : MonoBehaviour 
{
    [SerializeField]
    private PartyTrainer trainer;

    [SerializeField]
    private List<PartyMonsterInfo> monstersInfo;

    public ReadOnlyCollection<PartyMonsterInfo> MonstersInfo { get; private set; }
    public PartyTrainer Trainer { get { return trainer; } }
    public bool Encountered;

    private void Awake()
    {
        MonstersInfo = new ReadOnlyCollection<PartyMonsterInfo>(monstersInfo);
    }

    public void SetMonstersInfo(List<PartyMonsterInfo> mInfo)
    {
        monstersInfo = mInfo;
        MonstersInfo = new ReadOnlyCollection<PartyMonsterInfo>(monstersInfo);
    }
}
