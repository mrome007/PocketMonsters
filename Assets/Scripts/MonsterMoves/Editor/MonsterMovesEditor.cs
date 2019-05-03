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
        DrawUpdateMonsterMovesCategory();
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

    private void DrawUpdateMonsterMovesCategory()
    {
        if(GUILayout.Button("Update Move Categories"))
        {
            GUI.changed = UpdateMonsterMovesCategory();
        }
    }

    private bool UpdateMonsterMovesCategory()
    {
        var updated = false;
        foreach(Transform child in monsterMoves.transform)
        {
            var move = child.GetComponent<MonsterMove>();

            if(move.Category == MonsterMoveCategory.PHYSICAL || move.Category == MonsterMoveCategory.SPECIAL)
            {
                if(move.Type == MonsterType.WATER || move.Type == MonsterType.GRASS || move.Type == MonsterType.FIRE || move.Type == MonsterType.ICE
                   || move.Type == MonsterType.ELECTRIC || move.Type == MonsterType.PSYCHIC || move.Type == MonsterType.DRAGON || move.Type == MonsterType.DARK)
                {
                    if(!updated)
                    {
                        updated = move.Category != MonsterMoveCategory.SPECIAL;
                    }
                    move.Category = MonsterMoveCategory.SPECIAL;
                }
                else
                {
                    if(!updated)
                    {
                        updated = move.Category != MonsterMoveCategory.SPECIAL;
                    }
                    move.Category = MonsterMoveCategory.PHYSICAL;
                }
            }
        }

        return updated;
    }
}
