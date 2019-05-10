using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour 
{
    private void Awake()
    {
        if(SaveGameSystem.CanSaveOrLoad())
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(SaveGameSystem.SaveGame);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
