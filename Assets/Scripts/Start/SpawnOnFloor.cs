using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;
#if !UNITY_EDITOR && UNITY_METRO
using System.Threading;
using System.Threading.Tasks;
#endif

public class SpawnOnFloor : MonoBehaviour
{
    Vector3 originalPosition;
    public Collider platformColl;
    private Boolean planesDone;
    private Boolean EndingCalled;
    
   
    // Use this for initialization
    void Start()
    {

        this.GetComponent<Renderer>().enabled = false;
        //platformColl = GetComponent<Collider>();
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += StartGame;
        EndingCalled = false;
        
    }
    void Update()
    {
        var headPosition = Camera.main.transform.position;
        RaycastHit onObject;
        if (Physics.Raycast(headPosition, Vector3.down, out onObject)){
            if ((RunningManager.Instance.p1Start == true && RunningManager.Instance.p1End == false))
            {
                if (onObject.collider.gameObject == this.gameObject)
                {
                    this.GetComponent<Renderer>().enabled = true;
                    this.GetComponent<Renderer>().material.color = Color.green;

                    if (EndingCalled == false)
                    {
                        EndingCalled = true;
                        Invoke("IsStanding", 3F);
                    }
                }
                else if (planesDone == true)
                {
                    this.GetComponent<Renderer>().enabled = true;
                    this.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
            else if (RunningManager.Instance.pause == true)
            {
                this.GetComponent<Renderer>().enabled = false;
            }
        }
        
    }
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        if ((RunningManager.Instance.p3Start == true && RunningManager.Instance.p3End == false))
        {
            RunningManager.Instance.EndPhase();
        }


    }

   
    void OnReset()
    {
        
        this.transform.localPosition = originalPosition;
    }

    
    
    public void StartGame(object Object, EventArgs e)
    {
        planesDone = true;
        float currentfloor = SurfaceMeshesToPlanes.Instance.FloorYPosition;
        Vector3 spawnin =  new Vector3(CalcRealtiveFloorPos().x, currentfloor+0.05F, CalcRealtiveFloorPos().z);
        this.transform.position = spawnin;
    }

    public Vector3 CalcRealtiveFloorPos()
    {
        Vector3 temp = PatientSpawnSingleton.currentLoc;
        float x = 2.5F;
        float circle = ((4-SetEndSingleton.platformPos1)/4)*x;
        float line = SetEndSingleton.platformPos2;
        
        Vector3 PlatformXZ = new Vector3(temp.x + ((float)(circle*Math.Sin(2 * Math.PI * (line/12)))), 0F, temp.z + ((float)(circle*Math.Cos(2 * Math.PI * (line / 12)))));
        return PlatformXZ;
    }

    public void IsStanding()
    {
        var headPosition = Camera.main.transform.position;
        RaycastHit onObject;
        if (Physics.Raycast(headPosition, Vector3.down, out onObject))
        {
            if (onObject.collider.gameObject == this.gameObject)
            {
                RunningManager.Instance.EndPhase();
            }
        }
        EndingCalled = false;
    }
}