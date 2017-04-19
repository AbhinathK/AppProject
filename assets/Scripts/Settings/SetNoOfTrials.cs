using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetNoOfTrials : MonoBehaviour
{
    public void OnGazeEnter()
    {
        GetComponent<Button>().OnPointerEnter(null);
    }

    public void OnGazeLeave()
    {
        GetComponent<Button>().OnPointerExit(null);
    }

    public void OnSelect()
    {
        GlobalPositionTracker.Instance.UpdateRotation(Camera.main.transform.rotation);
        GlobalPositionTracker.Instance.UpdatePos(Camera.main.transform.position);
        Application.LoadLevel("SetNoTrials");
    }


}