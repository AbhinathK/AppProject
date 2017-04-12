using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPatientSpawn : MonoBehaviour {

    public static Boolean spawnIsSet { get; private set; }
    public static Vector3 currentLoc { get; private set; }

    public static SetPatientSpawn Instance { get; private set; }

    

    // Use this for initialization
    void Start () {

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        spawnIsSet = false;

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

    void OnSelect()
    {
        currentLoc = Camera.main.gameObject.transform.position;
        spawnIsSet = true;
    }
}
