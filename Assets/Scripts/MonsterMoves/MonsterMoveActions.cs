using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class MonsterMoveActions : MonoBehaviour 
{
    #region Instance

    private MonsterMoveActions instance = null;

    private MonsterMoveActions Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<MonsterMoveActions>();
            }
            return instance;
        }
    }

    #endregion

    #region Inspector Fields

    [SerializeField]
    private int numberOfActionsPerPool = 10;

    #endregion

    #region Private Fields

    private Dictionary<string, List<MonsterMoveAction>> monsterMoveActionsPool;

    #endregion
   
    private void Awake()
    {
        if(instance == null)
        {
            instance = GameObject.FindObjectOfType<MonsterMoveActions>();
        }
        PopulateMonsterMoveActionsPool();
    }

    private void PopulateMonsterMoveActionsPool()
    {
        if(monsterMoveActionsPool != null)
        {
            return;
        }

        monsterMoveActionsPool = new Dictionary<string, List<MonsterMoveAction>>();
        
        Type[] types = Assembly.GetExecutingAssembly().GetTypes();
        Type[] moveActionTypes = (from Type type in types where type.IsSubclassOf(typeof(MonsterMoveAction)) select type).ToArray();

        foreach(var type in moveActionTypes)
        {
            var moveActions = new List<MonsterMoveAction>();
            var typeName = type.ToString();
            if(!monsterMoveActionsPool.ContainsKey(typeName))
            {
                for(var count = 0; count < numberOfActionsPerPool; count++)
                {
                    var moveAction = Activator.CreateInstance(type, null, MonsterTarget.ENEMY, 0);
                    moveActions.Add((MonsterMoveAction)moveAction);
                }
                monsterMoveActionsPool.Add(typeName, moveActions);
            }
        }
    }
}
