using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<TextMesh>().text = SetEndSingleton.Instance.getPlat1().ToString() + "," + SetEndSingleton.Instance.getPlat2().ToString() + "," + GlobalPositionTracker.globalPosOffset.x.ToString();

    }
}
