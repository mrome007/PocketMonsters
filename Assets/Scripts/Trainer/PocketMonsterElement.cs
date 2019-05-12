using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketMonsterElement : MonoBehaviour 
{
    public string ElementName;

    [SerializeField]
    private bool disableAtStart;

    private void Awake()
    {
        PocketMonsterElementController.AddPocketMonsterElements(this);
        gameObject.SetActive(!disableAtStart);
    }
}
