﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;
#if !UNITY_EDITOR && UNITY_METRO
using System.Threading;
using System.Threading.Tasks;
#endif


public class RunningManager : MonoBehaviour {

    public Boolean p1Start { get; private set; }
    public Boolean p1End { get; private set; }
    public Boolean p3Start { get; private set; }
    public Boolean p3End { get; private set; }
    public Boolean pause { get; private set; }

    public static RunningManager Instance { get; private set; }

    // Use this for initialization
    void Start() {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        p1Start = false;
        p1End = false;
        p3Start = false;
        p3End = false;
        pause = false;
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update() {

    }

    public void StartP1()
    {
        p1Start = true;
    }
    public void StartP3()
    {
        p1Start = true;
    }
    public void EndP1()
    {
        p1End = true;
    }
    public void EndP3()
    {
        p1End = true;
    }


    public void EndPhase()
    {
        if (RunningManager.Instance.p1Start == true && RunningManager.Instance.p1End == false)
        {
            p1End = true;
            pause = true;
            Invoke("StartNextPhase",DelayTimeSingleton.delayTime);
        } else if (RunningManager.Instance.p3Start == true && RunningManager.Instance.p3Start == false)
        {
            EndTrial();
        }
    }

    public void StartNextPhase()
    {
        p3Start = true;
        pause = false;
    }
    
    public void EndTrial()
    {
        GlobalPositionTracker.Instance.UpdatePos(Camera.main.transform.position);
        Application.LoadLevel("MainMenu");
    }

}
