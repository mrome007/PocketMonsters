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

    public MonsterParty MonstersParty { get; protected set; }
    public PartyTrainer Trainer { get { return trainer; } }
    public bool Encountered;

    protected virtual void Awake()
    {
        MonstersParty = new MonsterParty();
        for(var index = 0; index < monstersInfo.Count; index++)
        {
            MonstersParty.AddMonsterToParty(index, monstersInfo[index]);
        }
    }
}
