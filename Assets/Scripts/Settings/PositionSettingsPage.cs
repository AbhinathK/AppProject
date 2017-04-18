using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSettingsPage : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        this.gameObject.transform.rotation= (GlobalPositionTracker.globalRotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
