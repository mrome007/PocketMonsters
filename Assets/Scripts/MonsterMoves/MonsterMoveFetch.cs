using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveFetch : MonoBehaviour 
{
    public MonsterMove GetMonsterMove(string name)
    {
        foreach(Transform child in transform)
        {
            var move = child.GetComponent<MonsterMove>();

            if(move == null)
            {
                continue;
            }

            if(move.name == name)
            {
                return move;
            }
        }

        return null;
    }

    public MonsterMove GetMonsterMove(int index)
    {
        if(index < 0 || index >= transform.childCount)
        {
            return null;
        }

        return transform.GetChild(index).GetComponent<MonsterMove>();
    }
}
