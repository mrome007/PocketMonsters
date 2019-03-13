using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenEnemyImage : BattleScreenImage
{
    [SerializeField]
    private List<Sprite> enemyTrainerSprites;

    public override Sprite GetScreenImage(BattleStateArgs battleArgs)
    {
        if(battleArgs.EnemyWildEncounter)
        {
            return battleArgs.GetFirstMonsterSprite(true, false);
        }
        else
        {
            return enemyTrainerSprites[(int)battleArgs.EnemyTrainer];
        }
    }
}
