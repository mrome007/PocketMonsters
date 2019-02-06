using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketMonsterParty : MonoBehaviour, IEnumerable<LightMonster> 
{
    [SerializeField]
    private List<LightMonster> party;

    public int NumberOfMonsters { get { return party == null ? 0 : party.Count;  } }
    private bool wildEncounter;
    public bool WildEncounter { get { return wildEncounter; } }
    private PartyTrainer partyTrainer;
    public PartyTrainer PartyTrainer { get { return partyTrainer; } }

    public LightMonster First
    {
        get
        {
            if(party == null || party.Count == 0)
            {
                return null;
            }

            return party[0];
        }
    }

    public void AddMonster(LightMonster monster, bool wild = true, PartyTrainer trainer = PartyTrainer.NONE)
    {
        wildEncounter = wild;
        partyTrainer = trainer;
        if(party == null)
        {
            party = new List<LightMonster>();
        }

        if(wild)
        {
            if(party.Count > 0)
            {
                party[0] = monster;
                return;
            }
        }
        party.Add(monster);
    }

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (party as IEnumerable).GetEnumerator();
    }

    public IEnumerator<LightMonster> GetEnumerator()
    {
        return party.GetEnumerator();
    }

    #endregion
}

public enum PartyTrainer
{
    NONE,
    RED,
    BLUE,
    YELLOW
}
