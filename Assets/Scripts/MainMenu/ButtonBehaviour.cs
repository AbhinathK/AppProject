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
        if (PatientSpawnSingleton.spawnIsSet == true) {
            GlobalPositionTracker.Instance.UpdatePos(Camera.main.transform.position);
            GlobalPositionTracker.Instance.UpdateRotation(Camera.main.transform.rotation);
            if (TrialNumSingleton.trialsIsLocked == false)
            {
                OutputToFile.InitialiseFileStart = true;
                TrialNumSingleton.trialsIsLocked = true;
            }
            
            
            Application.LoadLevel("MorrisWaterMaze");
            
        }
    }
}