using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int BaseStatTotal { get; private set; }

    public int BaseHP;
    public int BaseAttack;
    public int BaseDefense;
    public int BaseSpecial;
    public int BaseSpeed;

    private void Awake()
    {
        BaseStatTotal = BaseHP + BaseAttack + BaseDefense + BaseSpecial + BaseSpeed;
    }
}
