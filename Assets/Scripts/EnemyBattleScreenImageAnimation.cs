using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleScreenImageAnimation : BattleScreenImageAnimation
{
    private SpriteRenderer enemySpriteRenderer;
    private BattleScreenEnemyImage enemyImage;

    protected override void Awake()
    {
        base.Awake();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        enemyImage = GetComponent<BattleScreenEnemyImage>();
    }

    public override void PlayToView(PocketMonsterParty party)
    {
        enemySpriteRenderer.sprite = enemyImage.GetScreenImage(party);
        base.PlayToView(party);
    }
}
