using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBattleScreenStatus : MonoBehaviour 
{
    [SerializeField]
    protected SpriteRenderer battleScreenImage;
    [SerializeField]
    protected Text monsterName;
    [SerializeField]
    protected Text levelNumber;
    [SerializeField]
    protected Slider hpSlider;
}
