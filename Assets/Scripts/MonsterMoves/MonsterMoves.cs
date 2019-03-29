using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoves : MonoBehaviour 
{
    private static MonsterMoves instance;

    private static MonsterMoves Instance
    {
        get 
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<MonsterMoves>();
            }
            return instance; 
        }
    }

    public MonsterMoveFetch MonsterMoveFetch;

    private void Awake()
    {
        if(instance == null)
        {
            instance = GameObject.FindObjectOfType<MonsterMoves>();
        }
    }

    public static MonsterMove GetMonsterMove(int index)
    {
        return instance.MonsterMoveFetch.GetMonsterMove(index);
    }
}
