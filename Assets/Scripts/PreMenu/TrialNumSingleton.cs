using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class TrialNumSingleton : MonoBehaviour
{
    public static Boolean trialsIsLocked { get; set; }
    public static float trialsNum { get; private set; }
    public static TrialNumSingleton Instance { get; private set; }

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        trialsIsLocked = false;
        trialsNum = 1;

        DontDestroyOnLoad(gameObject);
    }

    public void SetTrials(float x)
    {
        trialsNum = x;

    }
}