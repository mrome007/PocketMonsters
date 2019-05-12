using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PocketMonsterElementController
{
    private static List<PocketMonsterElement> pocketMonsterElements;

    public static void AddPocketMonsterElements(PocketMonsterElement element)
    {
        if(pocketMonsterElements == null)
        {
            pocketMonsterElements = new List<PocketMonsterElement>();
        }

        pocketMonsterElements.Add(element);
    }

    public static void ShowPocketMonsterElement(string name, bool show)
    {
        var found = pocketMonsterElements.Find(element => element.ElementName == name);

        if(found == null)
        {
            return;
        }

        pocketMonsterElements.ForEach(element => element.gameObject.SetActive(false));
        found.gameObject.SetActive(show);
    }
}
