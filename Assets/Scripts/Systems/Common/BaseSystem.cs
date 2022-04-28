using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BaseSystem : MonoBehaviour
{
    protected ResService resService;
    protected AudioService audioService;
    protected InputService inputService;

    public virtual void Init(ResService resService = null, AudioService audioService = null,
        InputService inputService = null)

    {
        this.resService = resService;
        this.audioService = audioService;
        this.inputService = inputService;
    }
}
