using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenIntroEnemyImage : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> enemyTrainerSprites;

    public Sprite GetEnemySprite(PocketMonsterParty enemy)
    {
        if(enemy.WildEncounter)
        {
            return enemy.First.Front;
        }
        else
        {
            return enemyTrainerSprites[(int)enemy.PartyTrainer - 1];
        }
    }
}
