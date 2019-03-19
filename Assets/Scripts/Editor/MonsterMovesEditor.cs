using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(MonsterMoves))]
public class MonsterMovesEditor : Editor
{
    private MonsterMoves monsterMoves;

    private void OnEnable()
    {
        monsterMoves = target as MonsterMoves;
    }

    public override void OnInspectorGUI()
    {
        if(monsterMoves == null)
        {
            monsterMoves = target as MonsterMoves;
        }

        monsterMoves.MonsterMoveFetch = EditorGUILayout.ObjectField("Fetch Moves: ", monsterMoves.MonsterMoveFetch,
            typeof(MonsterMoveFetch), true) as MonsterMoveFetch;

        DrawUpdateMonsterMoves();
        if(GUI.changed)
        {
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }

    private void DrawUpdateMonsterMoves()
    {
        if(GUILayout.Button("Populate Monster Moves"))
        {
            GUI.changed = UpdateMonsterMoveIndex(); //TODO if in the future there are other methods that can update monster moves just add an OR to this statement.
        }
    }

    private bool UpdateMonsterMoveIndex()
    {
        var updated = false;
        foreach(Transform child in monsterMoves.transform)
        {
            var monsterMove = child.GetComponent<MonsterMove>();
            if(monsterMove.MIndex != child.GetSiblingIndex())
            {
                updated = true;
                monsterMove.MIndex = child.GetSiblingIndex();
            }
        }

        return updated;
    }
}
