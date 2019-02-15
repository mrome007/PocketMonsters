using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleScreenImageAnimation : BattleScreenImageAnimation
{
    private SpriteRenderer enemySpriteRenderer;
    private BattleScreenIntroEnemyImage enemyImage;

    protected override void Awake()
    {
        base.Awake();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        enemyImage = GetComponent<BattleScreenIntroEnemyImage>();
    }

    public override void PlayToView(PocketMonsterParty party)
    {
        enemySpriteRenderer.sprite = enemyImage.GetEnemySprite(party);
        base.PlayToView(party);
    }
}
