using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBattleScreenStatus : MonoBehaviour 
{
    [SerializeField]
    protected Text monsterName;
    [SerializeField]
    protected Text levelNumber;
    [SerializeField]
    protected Slider hpSlider;

    public virtual void UpdateMonsterStatus(string monsterName, ushort levelNumber, ushort currentHP, ushort monsterHP)
    {
        this.monsterName.text = monsterName;
        this.levelNumber.text = levelNumber.ToString();
        var hpPercentage = 1f * currentHP / monsterHP;
        hpSlider.value = hpPercentage;
    }
}
