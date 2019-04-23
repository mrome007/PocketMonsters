using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class MonsterMoveActions : MonoBehaviour 
{
    #region Instance

    private static MonsterMoveActions instance = null;

    private static MonsterMoveActions Instance
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
    private Dictionary<string, int> monsterMoveActionsPoolIndexes;

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
        monsterMoveActionsPoolIndexes = new Dictionary<string, int>();
        
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
                    var moveAction = Activator.CreateInstance(type, null, null, MonsterTarget.ENEMY, 0);
                    moveActions.Add((MonsterMoveAction)moveAction);
                }
                monsterMoveActionsPool.Add(typeName, moveActions);
                monsterMoveActionsPoolIndexes.Add(typeName, numberOfActionsPerPool - 1);
            }
        }
    }

    public static MonsterMoveAction GetMonsterMoveAction(Type type)
    {
        MonsterMoveAction moveAction = null;
        var typeName = type.ToString();

        if(Instance.monsterMoveActionsPool.ContainsKey(typeName) && Instance.monsterMoveActionsPoolIndexes.ContainsKey(typeName))
        {
            var currentIndex = Instance.monsterMoveActionsPoolIndexes[typeName];
            var pool = Instance.monsterMoveActionsPool[typeName];

            if(currentIndex >= 0)
            {
                moveAction = pool[currentIndex];
                Instance.monsterMoveActionsPoolIndexes[typeName]--;
            }
        }

        return moveAction;
    }

    public static void ReturnMonsterMoveAction(Type type, MonsterMoveAction move)
    {
        var typeName = type.ToString();
        if(Instance.monsterMoveActionsPool.ContainsKey(typeName) && Instance.monsterMoveActionsPoolIndexes.ContainsKey(typeName))
        {
            var currentIndex = Instance.monsterMoveActionsPoolIndexes[typeName];
            var pool = Instance.monsterMoveActionsPool[typeName];

            if(currentIndex < pool.Count)
            {
                move.Reset();
                Instance.monsterMoveActionsPoolIndexes[typeName]++;
            }
        }
    }
}
