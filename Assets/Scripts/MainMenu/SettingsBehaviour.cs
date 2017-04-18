using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class SettingsBehaviour : MonoBehaviour
{

    
    public void OnGazeEnter()
    {
        GetComponent<Button>().OnPointerEnter(null);
    }

    public void OnGazeLeave()
    {
        GetComponent<Button>().OnPointerExit(null);
    }

    void Update()
    {
        this.GetComponentInChildren<Text>().text = (GlobalPositionTracker.globalPosOffset + Camera.main.transform.position).x.ToString();
    }
    public void OnSelect()
    {
        GlobalPositionTracker.Instance.UpdatePos(Camera.main.transform.position);
        GlobalPositionTracker.Instance.UpdateRotation(Camera.main.transform.rotation);
        Application.LoadLevel("Settings");
    }
}   