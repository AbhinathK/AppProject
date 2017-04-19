using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEndSingleton : MonoBehaviour
{
    public static Boolean platformIsSet { get; private set; }
    public static Boolean circleIsSet { get; private set; }
    public static Boolean lineIsSet { get; private set; }
    public static float platformPos1 { get; private set; }
    public static float platformPos2 { get; private set; }

    public static SetEndSingleton Instance { get; private set; }

    void Start()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        platformIsSet = false;
        circleIsSet = false;
        lineIsSet = false;
        platformPos1 = 0F;
        platformPos2 = 0F;
        DontDestroyOnLoad(gameObject);
    }

    public void SetCircle(float x)
    {
        platformPos1 = x;
        circleIsSet = true;

    }

    public void SetLine(float x)
    {
        platformPos2 = x;
        lineIsSet = true;
        platformIsSet = true;

    }

    public float getPlat1()
    {
        return platformPos1;
    }
    public float getPlat2()
    {
        return platformPos2;
    }
}