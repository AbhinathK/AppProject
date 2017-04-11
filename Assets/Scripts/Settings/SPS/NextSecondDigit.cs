﻿using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class NextSecondDigit : MonoBehaviour
{


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
        Application.LoadLevel("SetPlatformSpawn3");
    }
}