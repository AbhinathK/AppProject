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
        if (PatientSpawnSingleton.spawnIsSet == true)
        {
            this.GetComponentInChildren<Text>().text = "Set patient spawn \n\n Set";
        }
    }
    void OnSelect()
    {

        PatientSpawnSingleton.Instance.SetLoc(Camera.main.transform.position);
        
    }
}
