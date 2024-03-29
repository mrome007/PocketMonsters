﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterBattleScreenImage : BattleScreenImage
{
    public override Sprite GetScreenImage(BattleStateArgs battleArgs)
    {
        return battleArgs.GetFirstMonsterSprite(false, true);
    }
}
