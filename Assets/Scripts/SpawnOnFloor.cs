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
    // Use this for initialization
    void Start()
    {
        planesDone = false;
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
        this.GetComponent<Renderer>().material.color = Color.red;
        platformColl = GetComponent<Collider>();
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += StartGame;
    }
    private void Update()
    {
        var headPosition = Camera.main.transform.position;
        RaycastHit onObject;
        if (Physics.Raycast(headPosition, Vector3.down, out onObject)){
            
            if(onObject.collider.gameObject == this.gameObject)
            {
                this.GetComponent<Renderer>().material.color = Color.green;
            }
            else if(planesDone == true)
            {
                this.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
        
    }
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        //SurfaceMeshesToPlanes reftemp = new SurfaceMeshesToPlanes
        float x = Camera.main.gameObject.transform.position.x;
        float currentfloor = SurfaceMeshesToPlanes.Instance.FloorYPosition;
        transform.position = new Vector3(0.5f, currentfloor, 0.5f);
    }

    // Called by SpeechManager when the user says the "Reset world" command
    void OnReset()
    {
        // If the sphere has a Rigidbody component, remove it to disable physics.
        this.transform.localPosition = originalPosition;
    }

    // Called by SpeechManager when the user says the "Drop sphere" command
    void OnDrop()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
    void StartGame(object source, EventArgs args)
    {
        planesDone = true;
    }
}