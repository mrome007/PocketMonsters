using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenEnemyImage : BattleScreenImage
{
    [SerializeField]
    private List<Sprite> enemyTrainerSprites;

    public override Sprite GetScreenImage(PocketMonsterParty party)
    {
        if(party.WildEncounter)
        {
            return party.First.Front;
        }
        else
        {
            return enemyTrainerSprites[(int)party.PartyTrainer];
        }
    }
}
