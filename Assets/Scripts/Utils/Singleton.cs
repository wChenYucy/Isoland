using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            return Singleton<T>.instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
           Destroy(gameObject);
           return;
        }
        instance = (T)this;
    }
}