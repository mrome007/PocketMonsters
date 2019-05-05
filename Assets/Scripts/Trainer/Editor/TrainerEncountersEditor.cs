using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
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

        DrawTrainerBattleEncounters();

        if(GUI.changed)
        {
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }

    private void DrawTrainerBattleEncounters()
    {
        foreach(var battle in trainerEncounters.trainerBattles)
        {
            battle.Encountered = EditorGUILayout.Toggle(battle.name, battle.Encountered);
        }
    }
}
