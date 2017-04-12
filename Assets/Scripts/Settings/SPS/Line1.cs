using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line1 : MonoBehaviour
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
        SetSpawn.Instance.SetLine(0.1F);
    }
}
