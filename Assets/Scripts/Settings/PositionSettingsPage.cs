﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSettingsPage : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Camera.main.transform.gameObject.transform.rotation = Quaternion.Euler(0, GlobalPositionTracker.globalRotation.eulerAngles.y, 0);
        this.gameObject.transform.rotation = Quaternion.Euler(0, GlobalPositionTracker.globalRotation.eulerAngles.y, 0);
        //Camera.main.transform.gameObject.transform.rotation = GlobalPositionTracker.globalRotation;
        //this.gameObject.transform.rotation = GlobalPositionTracker.globalRotation;
        Camera.main.transform.gameObject.transform.position = (GlobalPositionTracker.globalPosOffset);
        this.gameObject.transform.position = (GlobalPositionTracker.globalPosOffset);
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
