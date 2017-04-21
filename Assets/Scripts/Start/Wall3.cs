using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;
#if !UNITY_EDITOR && UNITY_METRO
using System.Threading;
using System.Threading.Tasks;
#endif



public class Wall3 : MonoBehaviour
{

    public Vector3 startPos { get; private set; }
    // Use this for initialization
    void Start()
    {
        startPos = PatientSpawnSingleton.currentLoc;
        this.GetComponent<Renderer>().enabled = false;
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += MoveWall3;

    }

    // Update is called once per frame
    void Update()
    {
        //if ((RunningManager.Instance.p1Start == true && RunningManager.Instance.p1End == false) || (RunningManager.Instance.p3Start == true && RunningManager.Instance.p1End == true && RunningManager.Instance.p3End == false))
        if ((RunningManager.Instance.p1Start == true && RunningManager.Instance.p1End == false))
        {

            this.GetComponent<Renderer>().enabled = true;
            this.GetComponent<Renderer>().material.color = Color.blue;
        }

    }

    void MoveWall3(object Object, EventArgs e)
    {
        float dimension = RoomSizeSingleton.roomSize;
        float currentfloor = SurfaceMeshesToPlanes.Instance.FloorYPosition;
        Vector3 startPlatformPos = new Vector3(startPos.x, currentfloor, startPos.z);
        this.transform.localScale = new Vector3(dimension, 0.1F, 0.1F);
        this.transform.position = startPlatformPos + new Vector3(0F, 0.05F, -dimension / 2);
        
    }
}
