using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSpawn : MonoBehaviour
{
    public static Boolean platformIsSet { get; private set; }
    public static Boolean circleIsSet { get; private set; }
    public static Boolean lineIsSet { get; private set; }
    public static float platformPos { get; private set; }

    public static SetSpawn Instance { get; private set; }

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

        DontDestroyOnLoad(gameObject);
    }

    public void OnGazeEnter()
    {
        GetComponent<Button>().OnPointerEnter(null);
    }

    public void OnGazeLeave()
    {
        GetComponent<Button>().OnPointerExit(null);
    }

    public void OnSelect()
    {
        Application.LoadLevel("SetPlatformSpawn");
    }

    public void SetCircle(float x)
    {
        platformPos = x;
        circleIsSet = true;

    }

    public void SetLine(float x)
    {
        platformPos = platformPos + x;
        lineIsSet = true;

    }
}