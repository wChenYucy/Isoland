using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class Teleport : MonoBehaviour
{
#if UNITY_EDITOR
    [SceneName]
#endif
    public string currentScene;
#if UNITY_EDITOR
    [SceneName]
#endif
    public string transitionScene;

    private SceneSystem _sceneSystem;


}
