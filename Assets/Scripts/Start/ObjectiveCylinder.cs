using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;
using UnityEngine.Audio;
#if !UNITY_EDITOR && UNITY_METRO
using System.Threading;
using System.Threading.Tasks;
#endif


public class ObjectiveCylinder : MonoBehaviour
{

    public Vector3 startPos { get; private set; }
    public Boolean atStart { get; private set; }

    //public static PlaceStartPlatform Instance { get; private set;} 
    // Use this for initialization
    void Start()
    {


        startPos = PatientSpawnSingleton.currentLoc;
        this.GetComponent<Renderer>().enabled = false;
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += cylinderObjective;

    }

    // Update is called once per frame
    void Update()
    {




        if (RunningManager.Instance.p1Start == true)
        {

            this.GetComponent<Renderer>().enabled = false;


        }
        /*
        else if(RunningManager.Instance.p3Start == false && RunningManager.Instance.p1End == true && RunningManager.Instance.pause == false)
        {
            RunningManager.Instance.StartP3();
            this.GetComponent<Renderer>().enabled = false;
        }*/



    }
    public void cylinderObjective(object Object, EventArgs e)
    {
        float currentfloor = SurfaceMeshesToPlanes.Instance.FloorYPosition;
        this.transform.position = new Vector3(startPos.x, currentfloor + 1F, startPos.z);
        this.GetComponent<Renderer>().enabled = true;
        this.GetComponent<Renderer>().material.color = Color.blue;

    }
}
