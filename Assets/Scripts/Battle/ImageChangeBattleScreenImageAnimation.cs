using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChangeBattleScreenImageAnimation : BattleScreenImageAnimation
{
    protected Image battleScreenUIImage;
    protected BattleScreenImage battleScreenImage;

    protected override void Awake()
    {
        base.Awake();
        battleScreenUIImage = GetComponent<Image>();
        battleScreenImage = GetComponent<BattleScreenImage>();
    }

    public override void PlayIdle(BattleStateArgs battleArgs)
    {
        battleScreenUIImage.sprite = battleScreenImage.GetScreenImage(battleArgs);
        base.PlayIdle(battleArgs);
    }
}
