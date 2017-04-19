using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPatientSpawn : MonoBehaviour {


    public void OnGazeEnter()
    {
        GetComponent<Button>().OnPointerEnter(null);
    }

    public void OnGazeLeave()
    {
        GetComponent<Button>().OnPointerExit(null);
    }

    private void Update()
    {
        this.GetComponentInChildren<Text>().text = (Camera.main.transform.position).x.ToString();
    }
    void OnSelect()
    {
        PatientSpawnSingleton.Instance.SetLoc(Camera.main.transform.position);
        
    }
}
