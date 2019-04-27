using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMonsterDetailedStatus : PlayerMonsterBattleScreenStatus
{
    [SerializeField]
    private Text attackStat;
    [SerializeField]
    private Text defenseStat;
    [SerializeField]
    private Text speedStat;
    [SerializeField]
    private Text specialStat;

    [SerializeField]
    private Text type1;
    [SerializeField]
    private Text type2;
    [SerializeField]
    private Text type1Label;
    [SerializeField]
    private Text type2Label;

    [SerializeField]
    private Text idNumber;
    [SerializeField]
    private Text ot;

    [SerializeField]
    private Text monsterNumber;
    [SerializeField]
    private Text statusLabel;
    [SerializeField]
    private Text status;
    [SerializeField]
    private Image monsterImage;

    public void UpdateDetailedStatus(Sprite monsterSprite, string trainer, string mName, LightMonsterStatus monsterStatus)
    {
        UpdateMonsterStatus(mName, monsterStatus.Level, monsterStatus.CurrentHP, monsterStatus.HP);
        monsterImage.sprite = monsterSprite;
        ot.text = trainer;
        attackStat.text = monsterStatus.Attack.ToString();
        defenseStat.text = monsterStatus.Defense.ToString();
        specialStat.text = monsterStatus.Special.ToString();
        speedStat.text = monsterStatus.Speed.ToString();

        type1.text = monsterStatus.PrimaryType.ToString();
        type2.text = monsterStatus.SecondaryType.ToString();

        type2.gameObject.SetActive(monsterStatus.SecondaryType != MonsterType.NONE);
        type2Label.gameObject.SetActive(monsterStatus.SecondaryType != MonsterType.NONE);

        idNumber.text = monsterStatus.IdNumber.ToString();
        ot.text = trainer;
        monsterNumber.text = monsterStatus.MonsterNumber.ToString();

        //TODO HIDE FOR NOW. FIGURE OUT HOW STATUSES ARE DONE LATER.
        statusLabel.gameObject.SetActive(false);
        status.gameObject.SetActive(false);
    }
}
