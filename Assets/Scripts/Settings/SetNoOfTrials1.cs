using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class SetNoOfTrials1 : MonoBehaviour
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

        this.GetComponentInChildren<Text>().text = "No. of Trials \n\n " + TrialNumSingleton.trialsNum.ToString() + " trials";

    }

    public void OnSelect()
    {
        GlobalPositionTracker.Instance.UpdateRotation(Camera.main.transform.rotation);
        GlobalPositionTracker.Instance.UpdatePos(Camera.main.transform.position);
        Application.LoadLevel("SetNoTrials");
    }


}