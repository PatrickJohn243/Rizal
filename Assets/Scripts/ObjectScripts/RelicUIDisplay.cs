using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RelicUIDisplay : MonoBehaviour
{
    public GameObject StoryUIcanvas;
    public bool isCanvasEnabled = false;

    public void EnableUI()
    {
        print("enabled");
        StoryUIcanvas.SetActive(true);
        isCanvasEnabled = true;
    }
}
