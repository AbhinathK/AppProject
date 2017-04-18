
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPositionTracker : MonoBehaviour {

    public static Vector3 globalPosOffset { get; private set; }
    public static Quaternion globalRotation { get; private set; }
    public static GlobalPositionTracker Instance { get; private set; }

    // Use this for initialization
    void Start () {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        globalPosOffset = new Vector3(0, 0, 0);
        globalRotation = new Quaternion();
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdatePos(Vector3 pos)
    {
        globalPosOffset = globalPosOffset + pos;
    }

    public void UpdateRotation(Quaternion rotation) {
        globalRotation = rotation;

    }
    
}
