using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class RelicUIDisplay : MonoBehaviour
{
    public GameObject StoryUIcanvas;
    public bool isCanvasEnabled = false;
    public TextMeshProUGUI canvasText;
    public textSO textSO;

    
    public void EnableFrameUI()
    {
        print("enabled");
        StoryUIcanvas.SetActive(true);
        canvasText.text = textSO.text;
        isCanvasEnabled = true;
    }
    public void EnableStandUI()
    {
        print("enabled");
        StoryUIcanvas.SetActive(true);
        isCanvasEnabled = true;
    }
}
