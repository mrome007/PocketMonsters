using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(PopulateMonsterMoves))]
public class PopulateMonsterMovesEditor : Editor
{
    private PopulateMonsterMoves populateMonsterMoves;

    private void OnEnable()
    {
        populateMonsterMoves = target as PopulateMonsterMoves;
    }

    public override void OnInspectorGUI()
    {
        if(populateMonsterMoves == null)
        {
            populateMonsterMoves = target as PopulateMonsterMoves;
        }

        populateMonsterMoves.MonsterMovesFile = EditorGUILayout.ObjectField("Monster Moves File: ", populateMonsterMoves.MonsterMovesFile, typeof(TextAsset), true) as TextAsset;
        populateMonsterMoves.Monsters = EditorGUILayout.ObjectField("Monsters Transform: ", populateMonsterMoves.Monsters, typeof(MonsterFetch), true) as MonsterFetch;
        populateMonsterMoves.MonsterMoves = EditorGUILayout.ObjectField("Monster Moves Transform: ", populateMonsterMoves.MonsterMoves, typeof(MonsterMoveFetch), true) as MonsterMoveFetch;

        DrawPopulateMonsterMoves();
        if(GUI.changed)
        {
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }

    private void DrawPopulateMonsterMoves()
    {
        if(GUILayout.Button("Populate Monster Moves"))
        {
            GUI.changed = PopulateMonsterMovesFromFile();
        }
    }

    private bool PopulateMonsterMovesFromFile()
    {
        var result = false;
        var xmlDoc = new XmlDocument();
        if(populateMonsterMoves.MonsterMovesFile == null)
        {
            return result;
        }
        xmlDoc.LoadXml(populateMonsterMoves.MonsterMovesFile.text);
        var pokemonList = xmlDoc.GetElementsByTagName("Pokemon");
        var pokemonIndex = 1;
        foreach(XmlNode pokemon in pokemonList)
        {
            var monster = populateMonsterMoves.Monsters.GetMonster(pokemonIndex);
            pokemonIndex++;
            if(monster.MovesByLevelUp.Count != 0)
            {
                continue;
            }

            foreach(XmlNode moves in pokemon.ChildNodes)
            {
                short lvlLearned = 0;
                short.TryParse(moves["Learned"].InnerText, out lvlLearned);
                var monsterMove = populateMonsterMoves.MonsterMoves.GetMonsterMove(moves["Move"].InnerText);
                if(monsterMove != null)
                {
                    result = true;
                    monster.MovesByLevelUp.Add(new LearnedMove(monsterMove, lvlLearned));
                }
            }
        }

        return result;
    }
}
