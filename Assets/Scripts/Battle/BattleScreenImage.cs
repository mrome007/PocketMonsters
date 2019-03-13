using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenImage : MonoBehaviour 
{
    public virtual Sprite GetScreenImage(BattleStateArgs battleArgs)
    {
        return battleArgs.GetFirstMonsterSprite(true, false);
    }
}
