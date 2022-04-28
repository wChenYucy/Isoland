using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : Singleton<GameRoot>
{
    private ResService _resService;
    private AudioService _audioService;
    private InputService _inputService;

    private SceneSystem _sceneSystem;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("游戏开始！");
        Init();
    }

    /// <summary>
    /// 初始化服务与系统
    /// </summary>
    private void Init()
    {
        //初始化服务
        _resService = GetComponent<ResService>();
        _resService.Init();
        _audioService = GetComponent<AudioService>();
        _audioService.Init();
        _inputService = GetComponent<InputService>();
        _inputService.Init();

        //初始化系统
        _sceneSystem = GetComponent<SceneSystem>();
        _sceneSystem.Init(_resService, _audioService, _inputService);
    }

    private void Update()
    {
        _inputService.Trick();
    }

    private void OnEnable()
    {
        _sceneSystem.Enable();
    }

    private void OnDisable()
    {
        _sceneSystem.Disable();
    }

    private void OnDestroy()
    {
        //注销系统
        _sceneSystem.Destroy();
        
        // 注销服务
    }
}
