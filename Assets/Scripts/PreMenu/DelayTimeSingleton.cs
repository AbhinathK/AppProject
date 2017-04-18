using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class DelayTimeSingleton : MonoBehaviour
{
    public static Boolean delayIsSet { get; private set; }
    public static float delayTime { get; private set; }
    public static DelayTimeSingleton Instance { get; private set; }

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        delayIsSet = false;

        DontDestroyOnLoad(gameObject);
    }

    public void SetDelay(float x)
    {
        delayTime = x;
        delayIsSet = true;

    }
}