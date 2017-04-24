using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
#if WINDOWS_UWP
using System;
using Windows.Storage;
using Windows.System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
#endif

public class OutputToFile : MonoBehaviour {

#if WINDOWS_UWP
    Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
    Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
#endif
    private static string timeStamp = System.DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
    private static string fileName = timeStamp + ".txt";
    private static Boolean TrialsStarted = false;
    private static float Trials = 1;
    private static float distance = 0;
    private static float lastX = 0;
    private static float lastZ = 0;
    private static Boolean timeStarted = false;
    private static DateTime timeStart = System.DateTime.Now;
    private static DateTime timeEnd = System.DateTime.Now;
    private static bool firstSave = true;
    public static OutputToFile Instance { get; private set; }
    public static Boolean InitialiseFileStart = false;
    public static Boolean InitialiseTrialStart = false;
    public static Boolean P1Complete = false;
    public static Boolean P3Started = false;
    private static Boolean TrialsStarted1 = false;

    //private static string timeStart = System.DateTime.Now.ToString("h:mm:ss tt");
    // Use this for initialization
    void Start () {


        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        




    }
    void Update()
    {
        if (InitialiseFileStart == true)
        {
            Invoke("InitialiseFile", 0F);
            InitialiseFileStart = false;
        }
        
        if (InitialiseTrialStart == true)
        {
            Invoke("StartTrial", 0F);
            InitialiseTrialStart = false;
        }

        if (TrialsStarted1 == true)
        {
            InvokeRepeating("WriteData1", 1.0f, 1.0f);
            TrialsStarted1 = false;
        }
        if (P1Complete == true)
        {
            Invoke("CompleteP1", 0F);
            P1Complete = false;
        }
        if (P3Started == true)
        {
            InvokeRepeating("WriteData2", 1.0f, 1.0f);
            P3Started = false;
        }
    }

	
    public void StartWrite()
    {
        Invoke("InitialiseFile", 0F);
    }

#if WINDOWS_UWP
    async void InitialiseFile(){
        Trials = TrialNumSingleton.trialsNum;
        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        await FileIO.AppendTextAsync(sampleFile, "Patient Name/ID" + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "Number of Trails " + TrialNumSingleton.trialsNum.ToString() + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "Delay Length " + DelayTimeSingleton.delayTime.ToString() + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "Room Size " + RoomSizeSingleton.roomSize.ToString() + "\r\n");
        InitialiseTrialStart = true;
        
        }
#endif
#if WINDOWS_UWP
    async void WriteData1()
    {
        if(RunningManager.Instance.p1Start == true && RunningManager.Instance.p1End == false){
            if(timeStarted == false)
            {
                timeStart = System.DateTime.Now;
                timeStarted = true;
            }
            Vector3 startPos = PatientSpawnSingleton.currentLoc;
            var headPosition = Camera.main.transform.position;
            lastX = headPosition.x - startPos.x;
            lastZ = headPosition.z - startPos.z;
            var positionRec = "X = " + (headPosition.x - startPos.x).ToString() + " Z = " + (headPosition.z - startPos.z).ToString();
            distance += (float)Math.Sqrt(Math.Pow((headPosition.x - startPos.x - lastX),2F) + Math.Pow((headPosition.z - startPos.z - lastZ), 2F));
            StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            await FileIO.AppendTextAsync(sampleFile, positionRec + "\r\n");
          }else if(RunningManager.Instance.p1End == true){

            CancelInvoke();
            timeEnd = System.DateTime.Now;
            Invoke("CompleteP1",0F);


    }
    }
#endif
#if WINDOWS_UWP
    async void WriteData2()
    {
        if (RunningManager.Instance.p3Start == true && RunningManager.Instance.p3End == false)
        {
            if (timeStarted == false)
            {
                timeStart = System.DateTime.Now;
                timeStarted = true;
            }
            Vector3 startPos = PatientSpawnSingleton.currentLoc;
            var headPosition = Camera.main.transform.position;
            lastX = headPosition.x - startPos.x;
            lastZ = headPosition.z - startPos.z;
            var positionRec = "X = " + (headPosition.x - startPos.x).ToString() + " Z = " + (headPosition.z - startPos.z).ToString();
            distance += (float)Math.Sqrt(Math.Pow((headPosition.x - startPos.x - lastX),2F) + Math.Pow((headPosition.z - startPos.z - lastZ), 2F));
            StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            await FileIO.AppendTextAsync(sampleFile, positionRec + "\r\n");
        }else if (RunningManager.Instance.p3End == true)
        {

            CancelInvoke();
            timeEnd = System.DateTime.Now;
            Invoke("CompleteP3", 0F);


        }
    }
#endif
#if WINDOWS_UWP

    async void StartTrial(){
        float Endpoint = SetEndSingleton.platformPos1 + SetEndSingleton.platformPos2/10;
        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
        await FileIO.AppendTextAsync(sampleFile, "Trail " + Endpoint.ToString() + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "Endpoint " + Endpoint.ToString() + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "Path Taken P1"+ "\r\n");
        TrialsStarted1 = true;
        
    }
#endif
#if WINDOWS_UWP
    async void CompleteP1()
    {
        TimeSpan totalTime = timeEnd - timeStart;
        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
        await FileIO.AppendTextAsync(sampleFile, "Start Time " + timeStart.ToString("h:mm:ss tt") + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "End Time " + timeEnd.ToString("h:mm:ss tt") + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "Time Elapsed " + totalTime.TotalSeconds.ToString() + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "Distance Travelled " + distance.ToString() + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "Path Taken P3" + "\r\n");
        timeStarted = false;
        distance = 0;
        P3Started = true;
    }
#endif
#if WINDOWS_UWP
    async void CompleteP3()
    {
        TimeSpan totalTime = timeEnd - timeStart;
        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
        await FileIO.AppendTextAsync(sampleFile, "Start Time " + timeStart.ToString("h:mm:ss tt") + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "End Time " + timeEnd.ToString("h:mm:ss tt") + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "Time Elapsed " + totalTime.TotalSeconds.ToString() + "\r\n");
        await FileIO.AppendTextAsync(sampleFile, "Distance Travelled " + distance.ToString() + "\r\n");
        timeStarted = false;
        Invoke("CheckTrials",1F);
    }
#endif
#if WINDOWS_UWP
    async void CheckTrials()
    {
        if(TrialsStarted == true){
            Trials = Trials-1;
    }
    if(Trials == 0){
            TrialsStarted = false;
    }else{
    InvokeRepeating("WriteData1", 1.0f, 1.0f);
    }
    }
#endif

}
