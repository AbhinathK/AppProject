using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class ReturnSettings4 : MonoBehaviour
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
        if (DelayTimeSingleton.delayIsSet == true)
        {
            GlobalPositionTracker.Instance.UpdateRotation(Camera.main.transform.rotation);
            GlobalPositionTracker.Instance.UpdatePos(Camera.main.transform.position);
            Application.LoadLevel("Settings");
        }
    }
}