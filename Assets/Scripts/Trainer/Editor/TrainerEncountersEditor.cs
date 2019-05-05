using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TrainerEncounters))]
public class TrainerEncountersEditor : Editor
{
    private TrainerEncounters trainerEncounters;

    private void OnEnable()
    {
        trainerEncounters = target as TrainerEncounters;
    }

    public override void OnInspectorGUI()
    {
        if(trainerEncounters == null)
        {
            trainerEncounters = target as TrainerEncounters;
        }
    }
}
