using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class RoomSizeSingleton : MonoBehaviour {

    // Use this for initialization
    public static Boolean sizeIsSet { get; private set; }
    public static float roomSize { get; private set; }
    public static RoomSizeSingleton Instance { get; private set; }

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        roomSize = 3F;
        sizeIsSet = false;

        DontDestroyOnLoad(gameObject);
    }

    public void SetRoomSize(float x)
    {
        roomSize = x;
        sizeIsSet = true;

    }
}
