using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFetch : MonoBehaviour 
{
    public Monster GetMonster(int index)
    {
        if(index < 0 || index >= transform.childCount)
        {
            return null;
        }

        return transform.GetChild(index).GetComponent<Monster>();
    }
}
