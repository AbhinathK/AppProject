using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialiseCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera.main.transform.position = GlobalPositionTracker.globalPosOffset;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
