using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TrainerEncounter : MonoBehaviour 
{
    [SerializeField]
    private PartyTrainer trainer;

    [SerializeField]
    protected List<PartyMonsterInfo> monstersInfo;

    public ReadOnlyCollection<PartyMonsterInfo> MonstersInfo { get; protected set; }
    public PartyTrainer Trainer { get { return trainer; } }
    public bool Encountered;

    protected virtual void Awake()
    {
        MonstersInfo = new ReadOnlyCollection<PartyMonsterInfo>(monstersInfo);
    }
}
