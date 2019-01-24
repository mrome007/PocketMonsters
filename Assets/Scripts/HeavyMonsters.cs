using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeavyMonsters : MonoBehaviour 
{
    #region Instance

    private static HeavyMonsters instance;

    //Make instance private. I don't like using Singletons when a static class can be used instead,
    //but I need MonoBehaviour capabilities such as getting the instance's children. I'm keeping
    //the instance private since I don't want to expose anything I shouldn't have to. I'll create
    //utility methods as needed.
    private static HeavyMonsters Instance
    {
        get 
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<HeavyMonsters>();
            }
            return instance; 
        }
    }

    #endregion

    private List<Monster> heavyMonsterReferences;

    private void Awake()
    {
        if(instance == null)
        {
            instance = GameObject.FindObjectOfType<HeavyMonsters>();
        }

        PopulateMonsterReferences();
    }

    private void PopulateMonsterReferences()
    {
        if(heavyMonsterReferences != null)
        {
            return;
        }
        
        heavyMonsterReferences = new List<Monster>();
        for(var index = 0; index < transform.childCount; index++)
        {
            var monster = transform.GetChild(index).GetComponent<Monster>();
            if(monster == null)
            {
                continue;
            }

            heavyMonsterReferences.Add(monster);
        }
    }

    public static Monster GetHeavyReference(int index)
    {
        if(index < 0 || index >= Instance.heavyMonsterReferences.Count)
        {
            return Instance.heavyMonsterReferences.FirstOrDefault();
        }

        return Instance.heavyMonsterReferences[index];
    }
}
