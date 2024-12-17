using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Canvasses")]
    [SerializeField] protected GameObject canvas;

    [Header("Fields")]
    public List<GameObject> EnabledCanvasList;
    public List<GameObject> UICanvas;
    public List<GameObject> PuzzleCanvas;
    public GameObject currentEnabledCanvas;

    //private ShowInteractableUI interactableUI;

    public bool isCanvasFound;

    public static event Action<bool> OnCanvasEnabled;

    private void Awake()
    {
        // = GetComponent<ShowInteractableUI>();
    }
    private void Start()
    {
        UICanvas = new List<GameObject>();
        UICanvas.Add(canvas);
        //UICanvas.Add(consumableInventory);
        //UICanvas.Add(keyItemInventory);
        //UICanvas.Add(journal);

        //PuzzleCanvas = new List<GameObject>();
        //PuzzleCanvas.Add(grandFathersClock);
        //PuzzleCanvas.Add(combinationLock);
        //PuzzleCanvas.Add(tvInterface);
        //PuzzleCanvas.Add(safeContent);
        //PuzzleCanvas.Add(chemicalRecipe);
        //PuzzleCanvas.Add(television);
        //PuzzleCanvas.Add(blueprint);

        DisableAllCanvas(UICanvas);
    }
    private void Update()
    {
        isCanvasFound = false;

        CheckEnabledCanvas(PuzzleCanvas);
        if (!isCanvasFound)
        {
            CheckEnabledCanvas(UICanvas);
        }
    }
    public void DisableAllCanvas(List<GameObject> canvasList)
    {
        foreach (GameObject canvas in canvasList)
        {
            canvas.SetActive(false);
        }
    }
    private void CheckEnabledCanvas(List<GameObject> canvasList)
    {
        EnabledCanvasList = canvasList;
        currentEnabledCanvas = null;
        foreach (GameObject canvas in canvasList)
        {
            if (canvas == null)
            {
                return;
            }
            if (canvas.activeSelf)
            {
                currentEnabledCanvas = canvas;
                isCanvasFound = true;
                SetCursorEnabled();
                //interactableUI.DisableInteractableUI();
                OnCanvasEnabled?.Invoke(true);
                return;
            }
        }
        if (currentEnabledCanvas != null)
        {
            foreach (GameObject canvas in canvasList)
            {
                if (canvas != currentEnabledCanvas)
                {
                    canvas.SetActive(false);
                }
            }
        }
        else if (currentEnabledCanvas == null)
        {
            SetCursorDisabled();
            OnCanvasEnabled?.Invoke(false);
        }
    }
    public void GetAndDisableCanvasList()
    {
        DisableAllCanvas(EnabledCanvasList);
    }
    public void SetCursorDisabled()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void SetCursorEnabled()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
