using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketMonsterParty : MonoBehaviour, IEnumerable<LightMonster> 
{
    [SerializeField]
    private List<LightMonster> party;

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

    public void AddMonster(LightMonster monster)
    {
        if(party == null)
        {
            party = new List<LightMonster>();
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
