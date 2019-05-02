using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformMonsterMoveAction : MonoBehaviour 
{
    #region Public members

    public event EventHandler<PerformMoveArgs> ImmediateActionStarted;
    public event EventHandler<PerformMoveArgs> ImmediateActionEnded;

    #endregion

    #region Inspector Data
    
    [SerializeField]
    private Animator playerMonsterAnimator;

    [SerializeField]
    private Animator enemyMonsterAnimator;

    [SerializeField]
    private Animator movePresentationAnimator;

    private PerformMoveArgs immediateStartedArgs;
    private PerformMoveArgs immediateEndedArgs;

    #endregion

    private void Awake()
    {
        InitializePerformArgs();
    }

    public void PerformMove(IEnumerable<string> moveSequences)
    {
        StartCoroutine(PerformMoveRoutine(moveSequences));
    }

    private IEnumerator PerformMoveRoutine(IEnumerable<string> moveSequences)
    {
        foreach(var move in moveSequences)
        {
            PostImmediateActionStarted(move);
            Debug.Log(move);
            yield return null;
            PostImmediateActionEnded(move);
        }
    }

    #region Post Events

    private void InitializePerformArgs()
    {
        immediateStartedArgs = new PerformMoveArgs("");
        immediateEndedArgs = new PerformMoveArgs("");
    }

    private void PostImmediateActionStarted(string move)
    {
        immediateStartedArgs.MoveAnimationName = move;
        var handler = ImmediateActionStarted;
        if(handler != null)
        {
            handler(this, immediateStartedArgs);
        }
    }

    private void PostImmediateActionEnded(string move)
    {
        immediateEndedArgs.MoveAnimationName = move;
        var handler = ImmediateActionEnded;
        if(handler != null)
        {
            handler(this, immediateEndedArgs);
        }
    }

    #endregion
}
