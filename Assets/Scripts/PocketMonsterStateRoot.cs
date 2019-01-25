using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketMonsterStateRoot : MonoBehaviour
{
    public PocketMonsterState State;
}

public enum PocketMonsterState
{
    NONE,
    OVERWORLD,
    BATTLE,
    MENU,
}
