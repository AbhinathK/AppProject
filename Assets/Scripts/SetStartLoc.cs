using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartLoc : MonoBehaviour {

    private Vector3 currentLoc;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSelect()
    {
        currentLoc = Camera.main.gameObject.transform.position;
    }

    public Vector3 GetStartPos()
    {
        return currentLoc;
    }
}
