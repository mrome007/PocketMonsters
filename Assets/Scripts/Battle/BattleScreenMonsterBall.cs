using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenMonsterBall : MonoBehaviour
{
    [SerializeField]
    private GameObject occupiedMonsterBall;
    [SerializeField]
    private GameObject vacantMonsterBall;
    [SerializeField]
    private GameObject faintedMonsterBall;

    public void ShowBattleScreenMonsterBall(bool occupied, bool faint = false)
    {
        if(faint)
        {
            faintedMonsterBall.SetActive(true);
            occupiedMonsterBall.SetActive(false);
            vacantMonsterBall.SetActive(false);
        }
        else
        {
            faintedMonsterBall.SetActive(false);
            occupiedMonsterBall.SetActive(occupied);
            vacantMonsterBall.SetActive(!occupied);
        }
    }
}
