using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenImage : MonoBehaviour 
{
    public virtual Sprite GetScreenImage(PocketMonsterParty party)
    {
        return party.First.Front;
    }
}
