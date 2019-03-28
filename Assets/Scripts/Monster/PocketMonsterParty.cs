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

    public int IdNumber { get; private set; }
    public int NumberOfMonsters { get { return party.Count(monster => monster.MonsterName != "Missing No."); } }
    public bool WildEncounter { get { return wildEncounter; } }
    public PartyTrainer PartyTrainer { get { return partyTrainer; } }
    private const int MAX_MONSTERS_IN_PARTY = 6;

    protected virtual void Awake()
    {
        party = new List<LightMonster>();
        HeavyMonsters.MonstersPopulated += HandleMonstersPopulated;
        GenerateRandomIdNumber();
    }

    protected virtual void OnDestroy()
    {
        HeavyMonsters.MonstersPopulated += HandleMonstersPopulated;
    }

    private void GenerateRandomIdNumber()
    {
        var num = 0;
        for(var count = 0; count < 6; count++)
        {
            num += Random.Range(0, 10) + (num * 10);
        }
        IdNumber = num;
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

    private MonsterMoveInfo?[] partyMovesContainer = new MonsterMoveInfo?[4];

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

            for(var index = 0; index < partyMovesContainer.Length; index++)
            {
                partyMovesContainer[index] = null;
            }

            //TODO clean this up.
            if(monsterInfo.MoveOne.MonsterMoveIndex >= 0)
            {
                partyMovesContainer[0] = MonsterMoves.GetMonsterMove(monsterInfo.MoveOne.MonsterMoveIndex).GetMonsterMoveInfoFromMonsterMove(monsterInfo.MoveOne.CurrentPP);
            }
            if(monsterInfo.MoveTwo.MonsterMoveIndex >= 0)
            {
                partyMovesContainer[1] = MonsterMoves.GetMonsterMove(monsterInfo.MoveTwo.MonsterMoveIndex).GetMonsterMoveInfoFromMonsterMove(monsterInfo.MoveTwo.CurrentPP);
            }
            if(monsterInfo.MoveThree.MonsterMoveIndex >= 0)
            {
                partyMovesContainer[2] = MonsterMoves.GetMonsterMove(monsterInfo.MoveThree.MonsterMoveIndex).GetMonsterMoveInfoFromMonsterMove(monsterInfo.MoveThree.CurrentPP);
            }
            if(monsterInfo.MoveFour.MonsterMoveIndex >= 0)
            {
                partyMovesContainer[3] = MonsterMoves.GetMonsterMove(monsterInfo.MoveFour.MonsterMoveIndex).GetMonsterMoveInfoFromMonsterMove(monsterInfo.MoveFour.CurrentPP);
            }

            var movesBundle = new MonsterMovesBundle(partyMovesContainer);
            party[count].InitializeMoves(movesBundle);
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
        return new LightMonsterStatus(monster.Level, monster.CurrentHP, monster.HPStat, (int)monster.BodyType);
    }

    public LightMonsterStatus GetMonsterStatusLightDetailed(int index)
    {
        if(index < 0 || index >= NumberOfMonsters)
        {
            return new LightMonsterStatus();
        }

        var monster = party[index];
        return new LightMonsterStatus(monster.Level, monster.CurrentHP, monster.HPStat, (int)monster.BodyType, 
            monster.MonsterNumber, IdNumber, monster.Type1, monster.Type2, monster.AttackStat, monster.DefenseStat,
            monster.SpecialStat, monster.SpeedStat);
    }

    public MonsterMovesBundle GetMoves(int index)
    {
        if(index < 0 || index >= NumberOfMonsters)
        {
            return new MonsterMovesBundle();
        }

        return party[index].GetMoves();
    }

    public Sprite GetMonsterSprite(int index, bool front)
    {
        if(index < 0 || index >= NumberOfMonsters)
        {
            return null;
        }
        
        return front ? party[index].Front : party[index].Back;
    }

    public void SwitchMonsters(int index)
    {
        if(index == 0 || (index < 0 || index >= NumberOfMonsters))
        {
            return;
        }

        var first = party[0];
        party[0] = party[index];
        party[index] = first;
    }

    public MonsterMoveInfo GetMonsterMoveInfo(int monsterIndex, int moveIndex)
    {
        var monster = party[monsterIndex];
        var monsterMoves = monster.GetMoves();
        if(moveIndex == 0)
        {
            return monsterMoves.MoveOne.Value;
        }
        else if(moveIndex == 1)
        {
            return monsterMoves.MoveTwo.Value;
        }
        else if(moveIndex == 2)
        {
            return monsterMoves.MoveThree.Value;
        }
        else
        {
            return monsterMoves.MoveFour.Value;
        }
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
