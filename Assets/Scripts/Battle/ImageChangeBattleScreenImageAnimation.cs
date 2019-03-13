using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageChangeBattleScreenImageAnimation : BattleScreenImageAnimation
{
    protected SpriteRenderer battleScreenSpriteRenderer;
    protected BattleScreenImage battleScreenImage;

    protected override void Awake()
    {
        base.Awake();
        battleScreenSpriteRenderer = GetComponent<SpriteRenderer>();
        battleScreenImage = GetComponent<BattleScreenImage>();
    }

    public override void PlayIdle(BattleStateArgs battleArgs)
    {
        battleScreenSpriteRenderer.sprite = battleScreenImage.GetScreenImage(battleArgs);
        base.PlayIdle(battleArgs);
    }
}
