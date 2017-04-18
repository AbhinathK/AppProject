using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientSpawnSingleton : MonoBehaviour
{

    public static Boolean spawnIsSet { get; private set; }
    public static Vector3 currentLoc { get; private set; }

    public static PatientSpawnSingleton Instance { get; private set; }



    // Use this for initialization
    void Start()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        currentLoc = new Vector3(0, 0, 0);
        Instance = this;
        spawnIsSet = false;

        DontDestroyOnLoad(gameObject);


    }


    public void SetLoc(Vector3 x)
    {
        currentLoc = x;
        spawnIsSet = true;
    }
}
