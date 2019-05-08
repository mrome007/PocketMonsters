using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(MonsterSprites))]
public class MonsterSpritesEditor : Editor
{
    private MonsterSprites monsterSprites;

    private void OnEnable()
    {
        monsterSprites = target as MonsterSprites;
    }

    public override void OnInspectorGUI()
    {
        if(monsterSprites == null)
        {
            monsterSprites = target as MonsterSprites;
        }

        monsterSprites.FrontMonsterSprites = EditorGUILayout.ObjectField("Front Sprite Sheet: ", 
            monsterSprites.FrontMonsterSprites, typeof(Texture2D), true) as Texture2D;
        monsterSprites.BackMonsterSprites = EditorGUILayout.ObjectField("Back Sprite Sheet: ", 
            monsterSprites.BackMonsterSprites, typeof(Texture2D), true) as Texture2D;

        DrawPopulateMonsterSprites();

        if(EditorApplication.isPlaying)
        {
            return;
        }

        if(GUI.changed)
        {
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }

    private void DrawPopulateMonsterSprites()
    {
        if(GUILayout.Button("Populate Monster Sprites"))
        {
            PopulateMonsterSprites();
            GUI.changed = true;
        }
    }

    private void PopulateMonsterSprites()
    {
        Sprite[] frontSprites = Resources.LoadAll<Sprite>(monsterSprites.FrontMonsterSprites.name);
        Sprite[] backSprites = Resources.LoadAll<Sprite>(monsterSprites.BackMonsterSprites.name);

        for(var index = 0; index < monsterSprites.transform.childCount; index++)
        {
            if(index == 0 || index >= frontSprites.Length || index >= backSprites.Length)
            {
                continue;
            }

            var child = monsterSprites.transform.GetChild(index);
            var monster = child.GetComponent<Monster>();
            if(monster != null)
            {
                monster.MonsterFrontSprite = frontSprites[index - 1];
                monster.MonsterBackSprite = backSprites[index - 1];
            }
        }
    }
}
