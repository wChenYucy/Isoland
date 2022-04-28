using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResService : MonoBehaviour
{
    public void Init()
    {
        Debug.Log("ResourceService初始化完成！");
    }

    public IEnumerator LoadSceneAsync(string sceneName , Action loadSceneFinishCallback = null, LoadSceneMode loadSceneMode = LoadSceneMode.Additive)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

        if (loadSceneMode == LoadSceneMode.Additive)
        {
            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene(newScene);
        }
        loadSceneFinishCallback?.Invoke();
    }

    public IEnumerator UnloadSceneAsync(string sceneName)
    {
        yield return SceneManager.UnloadSceneAsync(sceneName);
    }

}
