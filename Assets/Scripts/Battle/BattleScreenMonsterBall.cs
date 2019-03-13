using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenMonsterBall : MonoBehaviour
{
    [SerializeField]
    private GameObject occupiedMonsterBall;
    [SerializeField]
    private GameObject vacantMonsterBall;

    public void ShowBattleScreenMonsterBall(bool occupied)
    {
        occupiedMonsterBall.SetActive(occupied);
        vacantMonsterBall.SetActive(!occupied);
    }
}
