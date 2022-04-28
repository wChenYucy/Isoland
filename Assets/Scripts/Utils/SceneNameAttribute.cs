using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneNameAttribute : PropertyAttribute
{
#if UNITY_EDITOR
    public string[] NameList
    {
        get
        {
            return SceneNameAttribute.AllSceneNames();
        }
    }

    public static string[] AllSceneNames()
    {
        List<string> list = new List<string>();
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        for (int i = 0; i < scenes.Length; i++)
        {
            EditorBuildSettingsScene editorBuildSettingsScene = scenes[i];
            if (editorBuildSettingsScene.enabled)
            {
                string text = editorBuildSettingsScene.path.Substring(editorBuildSettingsScene.path.LastIndexOf('/') + 1);
                text = text.Substring(0, text.Length - 6);
                list.Add(text);
            }
        }
        return list.ToArray();
    }
#endif
    
}