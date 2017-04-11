using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class DoctorBehaviour : MonoBehaviour
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
        Application.LoadLevel("Settings");
    }
}