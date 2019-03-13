using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterBattleScreenImage : BattleScreenImage
{
    public override Sprite GetScreenImage(PocketMonsterParty party)
    {
        return party.First.Back;
    }
}
