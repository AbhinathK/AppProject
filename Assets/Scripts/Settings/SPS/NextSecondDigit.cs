using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class NextSecondDigit : MonoBehaviour
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
        if (SetEndSingleton.circleIsSet == true)
        {

            GlobalPositionTracker.Instance.UpdatePos(Camera.main.transform.position);
            Application.LoadLevel("SetPlatformSpawn3");
        }
    }
}