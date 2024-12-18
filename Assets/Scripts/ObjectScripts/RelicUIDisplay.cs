using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class RelicUIDisplay : MonoBehaviour
{
    [Header("Frames")]
    public GameObject FrameUIcanvas;
    public TextMeshProUGUI canvasText;
    public textSO textSO;

    [Header("Stands")]
    public GameObject StandUIcanvas;
    public Image image;
    public Sprite standImage;

    public void EnableFrameUI()
    {
        print("enabled Frame");
        FrameUIcanvas.SetActive(true);
        canvasText.text = textSO.text;
    }
    public void EnableStandUI()
    {
        print("enabled Stand");
        StandUIcanvas.SetActive(true);
        image.sprite = standImage;
    }
}
