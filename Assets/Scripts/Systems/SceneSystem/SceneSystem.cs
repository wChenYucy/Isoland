using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SceneSystem :BaseSystem
{
    public CanvasGroup fadeWindow;
    public override void Init(ResService resService = null, AudioService audioService = null, InputService inputService = null)
    {
        base.Init(resService, audioService, inputService);
        clickedTeleport = null;
        Debug.Log("Common System 初始化完成！");
    }

    public void Enable()
    {
        inputService.onLeftMouseButtonClick += isTeleportClick;
    }

    public void Disable()
    {
        inputService.onLeftMouseButtonClick -= isTeleportClick;
    }
    
    public void Destroy()
    {
        
    }

    public void ChangeScene(string currentSceneName, string changedSceneName)
    {
        inputService.CantClick();
        fadeWindow.DOFade(1, 0.2f).onComplete += () =>
        {
            StartCoroutine(TransitionToScene(currentSceneName, changedSceneName, () =>
            {
                fadeWindow.DOFade(0, 0.2f);
                inputService.CanClick();
            }));
        };

    }

    private IEnumerator TransitionToScene(string currentSceneName,string changedSceneName,Action onLoadFinishCallback = null)
    {
        yield return resService.UnloadSceneAsync(currentSceneName);
        yield return resService.LoadSceneAsync(changedSceneName, onLoadFinishCallback);
    }
    

    private Teleport clickedTeleport;
    public void isTeleportClick(GameObject gameObject)
    {
        if (gameObject.CompareTag("Teleport"))
        {
            clickedTeleport = gameObject.GetComponent<Teleport>();
            ChangeScene(clickedTeleport.currentScene, clickedTeleport.transitionScene);
            clickedTeleport = null;
        }
    }

    
}
