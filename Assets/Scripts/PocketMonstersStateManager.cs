using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketMonstersStateManager : MonoBehaviour
{
    [SerializeField]
    private List<PocketMonsterStateRoot> states;

    public void ShowState(PocketMonsterState currentState)
    {
        foreach(var state in states)
        {
            state.gameObject.SetActive(false);
            state.gameObject.SetActive(state.State == currentState);
        }
    }
}
