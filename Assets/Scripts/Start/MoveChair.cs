using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;

#if !UNITY_EDITOR && UNITY_METRO
using System.Threading;
using System.Threading.Tasks;
#endif

public class MoveChair : MonoBehaviour {
    public Vector3 startPos { get; private set; }
    // Use this for initialization
    void Start () {
        startPos = PatientSpawnSingleton.currentLoc;
        this.GetComponent<Renderer>().enabled = false;
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += MoveChair1;
    }
	
	// Update is called once per frame
	void Update () {
        if ((RunningManager.Instance.p1Start == true && RunningManager.Instance.p1End == false))
        {

            this.GetComponent<Renderer>().enabled = true;
            
        }
    }

    void MoveChair1(object Object, EventArgs e)
    {
        float dimension = RoomSizeSingleton.roomSize;
        float currentfloor = SurfaceMeshesToPlanes.Instance.FloorYPosition;
        var number = UnityEngine.Random.Range((-dimension/2), (dimension / 2));
        Vector3 startPlatformPos = new Vector3(startPos.x, currentfloor, startPos.z);
        this.transform.position = startPlatformPos + new Vector3(0, 0.05F, (dimension/2)+2);
        this.GetComponent<Renderer>().enabled = true;
    }
}
