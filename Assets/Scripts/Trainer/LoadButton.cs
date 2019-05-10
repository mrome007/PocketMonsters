using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour 
{
    private void Awake()
    {
        if(SaveGameSystem.CanSaveOrLoad())
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(SaveGameSystem.LoadGame);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
