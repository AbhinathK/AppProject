using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSpawn : MonoBehaviour
{   
    public void OnGazeEnter()
    {
        GetComponent<Button>().OnPointerEnter(null);
    }

    public void OnGazeLeave()
    {
        GetComponent<Button>().OnPointerExit(null);
    }

    public void Update()
    {
        float Endpoint = SetEndSingleton.platformPos1 + SetEndSingleton.platformPos2 / 10;
        this.GetComponentInChildren<Text>().text = "Set platform spawn \n\n " + Endpoint.ToString();

    }

    public void OnSelect()
    {
        GlobalPositionTracker.Instance.UpdateRotation(Camera.main.transform.rotation);
        GlobalPositionTracker.Instance.UpdatePos(Camera.main.transform.position);
        Application.LoadLevel("SetPlatformSpawn");
    }

   
}