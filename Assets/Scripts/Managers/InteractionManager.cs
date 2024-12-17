using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionManager : MonoBehaviour
{
    //public ShowInteractableUI showInteractableUI;
    private IInteractable interactableObj;
    private InteractableConfig interactable;

    [Header("Interaction Settings")]
    [SerializeField] private float interactionDistance = 5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private Transform cameraTransform;


    private int itemInteractedCase = 0;
    //public UnityEvent isInteracting;
    //public UnityEvent isNotInteracting;

    public bool isCanvasEnabled;

    public UnityEvent disableCanvas;
    private void OnEnable()
    {
        CanvasManager.OnCanvasEnabled += isAnyCanvasOn;
    }
    private void OnDisable()
    {
        CanvasManager.OnCanvasEnabled -= isAnyCanvasOn;
    }
    private void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }


    void Update()
    {
        Interact();
    }
    public void Interact()
    {
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * interactionDistance, Color.red);
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, interactionDistance, interactableMask))
        {
            Debug.DrawLine(cameraTransform.position, hit.point, Color.green);
            interactableObj = hit.collider.GetComponent<IInteractable>();

            if (interactableObj != null && !isCanvasEnabled)
            {
                //isInteracting.Invoke();
                interactable = interactableObj.GetInteractableConfig();
                //showInteractableUI.SetInteractionPrompt(interactable.promptImage);
                //showInteractableUI.EnableInteractableUI();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //print("interacting");
                    Debug.Log(interactableObj); 
                    switch (interactable.interactableType)
                    {
                        case InteractableType.letter:                           
                            itemInteractedCase = 0;
                            interactableObj.Interact(itemInteractedCase);
                            break;
                        case InteractableType.relic:
                            itemInteractedCase = 1;
                            interactableObj.Interact(itemInteractedCase);
                            break;
                    }
                }
            }
        }
        else
        {
            //showInteractableUI.DisableInteractableUI();
            //isNotInteracting.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Q) && isCanvasEnabled)
        {
            disableCanvas?.Invoke();
        }
    }
    public void isAnyCanvasOn(bool isOn)
    {
        isCanvasEnabled = isOn;
    }
}
