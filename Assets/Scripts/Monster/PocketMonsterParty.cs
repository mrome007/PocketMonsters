using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class PocketMonsterParty : MonoBehaviour, IEnumerable<LightMonster> 
{
    [SerializeField]
    private bool wildEncounter;

    [SerializeField]
    private PartyTrainer partyTrainer;

    private List<LightMonster> party;

    public int NumberOfMonsters { get { return party.Count(monster => monster.MonsterName != "Missing No."); } }
    public bool WildEncounter { get { return wildEncounter; } }
    public PartyTrainer PartyTrainer { get { return partyTrainer; } }
    private const int MAX_MONSTERS_IN_PARTY = 6;

    protected virtual void Awake()
    {
        party = new List<LightMonster>();
        HeavyMonsters.MonstersPopulated += HandleMonstersPopulated;
    }

    protected virtual void OnDestroy()
    {
        HeavyMonsters.MonstersPopulated += HandleMonstersPopulated;
    }

    protected virtual void HandleMonstersPopulated()
    {
        HeavyMonsters.MonstersPopulated -= HandleMonstersPopulated;
        PopulateParty();
    }

    private void PopulateParty()
    {
        if(party.Count == MAX_MONSTERS_IN_PARTY)
        {
            return;
        }

        for(var count = 0; count < MAX_MONSTERS_IN_PARTY; count++)
        {
            party.Add(new LightMonster(HeavyMonsters.GetHeavyReference(0)));
        }
    }

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

    public bool? IsMonsterAlive(int index)
    {
        if(index < 0 || index >= party.Count)
        {
            return null;
        }

        return party[index].CurrentHP != 0;
    }

    /// <summary>
    /// Adds a monster from wild encounter.
    /// </summary>
    /// <param name="monsterInfo">Monster info.</param>
    public void AddMonster(Vector2Int monsterInfo)
    {
        if(wildEncounter)
        {
            if(party.Count > 0)
            {
                party[0].Initialize(HeavyMonsters.GetHeavyReference(monsterInfo.x), (ushort)monsterInfo.y);
                return;
            }
        }
    }

    /// <summary>
    /// Adds a monster from trainer encounter.
    /// </summary>
    /// <param name="monsterInfo">Monster info.</param>
    public void AddMonster(ReadOnlyCollection<PartyMonsterInfo> monstersInfo)
    {
        var maxMonsters = monstersInfo.Count > MAX_MONSTERS_IN_PARTY ? MAX_MONSTERS_IN_PARTY : monstersInfo.Count;
        for(var count = 0; count < maxMonsters; count++)
        {
            var monsterInfo = monstersInfo[count];
            party[count].Initialize(HeavyMonsters.GetHeavyReference(monsterInfo.MonsterIndex), (ushort)monsterInfo.MonsterLevel);
        }
    }

    public void SetPartyTrainer(PartyTrainer trainer)
    {
        partyTrainer = trainer;
    }

    public string GetMonsterName(int index)
    {
        if(index < 0 || index >= NumberOfMonsters)
        {
            return string.Empty;
        }

        return party[index].MonsterName;
    }

    public LightMonsterStatus GetMonsterStatusLight(int index)
    {
        if(index < 0 || index >= NumberOfMonsters)
        {
            return new LightMonsterStatus();
        }

        var monster = party[index];
        return new LightMonsterStatus(monster.Level, monster.CurrentHP, monster.HPStat);
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
