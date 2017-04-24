using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class ButtonBehaviour : MonoBehaviour
{


    public void OnGazeEnter()
    {
        GetComponent<Button>().OnPointerEnter(null);
    }

    public void OnGazeLeave()
    {
        GetComponent<Button>().OnPointerExit(null);
    }

    public void OnSelect()
    {
        if (SetEndSingleton.platformIsSet == true && DelayTimeSingleton.delayIsSet == true && PatientSpawnSingleton.spawnIsSet == true) {
            GlobalPositionTracker.Instance.UpdatePos(Camera.main.transform.position);
            GlobalPositionTracker.Instance.UpdateRotation(Camera.main.transform.rotation);
            OutputToFile.InitialiseFileStart = true;
            Application.LoadLevel("MorrisWaterMaze");
            
        }
    }
}