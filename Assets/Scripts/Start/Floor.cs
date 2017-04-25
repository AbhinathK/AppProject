using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;
#if !UNITY_EDITOR && UNITY_METRO
using System.Threading;
using System.Threading.Tasks;
#endif



public class Floor : MonoBehaviour
{

    public Vector3 startPos { get; private set; }
    // Use this for initialization
    void Start()
    {
        startPos = PatientSpawnSingleton.currentLoc;
        this.GetComponent<Renderer>().enabled = false;
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += MoveFloor;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnSelect()
    {
        if ((RunningManager.Instance.p3Start == true && RunningManager.Instance.p3End == false))
        {
            RunningManager.Instance.EndPhase();
            GetComponent<AudioSource>().Play();

        }
        else if (RunningManager.Instance.p3Start == false && RunningManager.Instance.p1End == true && RunningManager.Instance.pause == false)
        {
            RunningManager.Instance.StartP3();
            GetComponent<AudioSource>().Play();

        }
    }
    void MoveFloor(object Object, EventArgs e)
    {
        float dimension = RoomSizeSingleton.roomSize;
        float currentfloor = SurfaceMeshesToPlanes.Instance.FloorYPosition;
        Vector3 startPlatformPos = new Vector3(startPos.x, currentfloor, startPos.z);
        this.transform.localScale = new Vector3(dimension, 0.1F, dimension);
        this.transform.position = startPlatformPos + new Vector3(0.0F, 0.05F, 0F);

    }
}
