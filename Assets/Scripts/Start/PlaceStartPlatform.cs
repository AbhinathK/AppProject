using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;
#if !UNITY_EDITOR && UNITY_METRO
using System.Threading;
using System.Threading.Tasks;
#endif


public class PlaceStartPlatform : MonoBehaviour
{

    public Vector3 startPos { get; private set; }
    public Boolean atStart { get; private set; }

    //public static PlaceStartPlatform Instance { get; private set;} 
	// Use this for initialization
	void Start () {

        
        startPos = PatientSpawnSingleton.currentLoc;
        this.GetComponent<Renderer>().enabled = false;
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += StartPlatformSpawn;
        
    }

    // Update is called once per frame
    void Update()
    {
        var headPosition = Camera.main.transform.position;
        RaycastHit onObject;
        if (Physics.Raycast(headPosition, Vector3.down, out onObject))
        {

            if (onObject.collider.gameObject == this.gameObject)
            {
                atStart = true;
                if(RunningManager.Instance.p1Start == false)
                {
                    RunningManager.Instance.StartP1();
                    this.GetComponent<Renderer>().enabled = false;

                }
                else if(RunningManager.Instance.p3Start == false && RunningManager.Instance.p1End == true && RunningManager.Instance.pause == false)
                {
                    RunningManager.Instance.StartP3();
                    this.GetComponent<Renderer>().enabled = false;
                }
            }
            else
            {
                atStart = false;
            }

        }
        if(RunningManager.Instance.pause == true)
        {
            this.GetComponent<Renderer>().enabled = false;
        }else if(RunningManager.Instance.pause == false && RunningManager.Instance.p3Start == false && RunningManager.Instance.p1End == true)
        {
            this.GetComponent<Renderer>().enabled = true;
        }
    }
    public void StartPlatformSpawn(object Object, EventArgs e)
    {
        float currentfloor = SurfaceMeshesToPlanes.Instance.FloorYPosition;
        this.transform.position = new Vector3(startPos.x, currentfloor+0.1F, startPos.z);
        this.GetComponent<Renderer>().enabled = true;
        this.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
