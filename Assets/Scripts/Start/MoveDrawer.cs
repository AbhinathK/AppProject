using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;

#if !UNITY_EDITOR && UNITY_METRO
using System.Threading;
using System.Threading.Tasks;
#endif

public class MoveDrawer : MonoBehaviour
{
    public Vector3 startPos { get; private set; }
    //public var Lamp1 : GameObject;
    // Use this for initialization
    void Start()
    {

        startPos = PatientSpawnSingleton.currentLoc;
        this.GetComponent<Renderer>().enabled = false;
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += MoveDrawer1;
    }

    // Update is called once per frame
    void Update()
    {
        if ((RunningManager.Instance.p1Start == true && RunningManager.Instance.p1End == false))
        {

            this.GetComponent<Renderer>().enabled = true;

        }
    }

    void MoveDrawer1(object Object, EventArgs e)
    {
        float dimension = RoomSizeSingleton.roomSize;
        float currentfloor = SurfaceMeshesToPlanes.Instance.FloorYPosition;
        var number = UnityEngine.Random.Range((-dimension / 2), (dimension / 2));
        Vector3 startPlatformPos = new Vector3(startPos.x, currentfloor, startPos.z);
        gameObject.transform.position = startPlatformPos + new Vector3((dimension / 2) + 2, 0.05F, number);
        gameObject.GetComponent<Renderer>().enabled = true;
        //GameObject obj = Instantiate(Lamp1, pos, rot) as GameObject;
        //gameObject.GetComponent<Renderer>().enabled = true;
    }
}
