using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public InteractableConfig interactableConfig;

    public virtual void Interact(int itemInteractedCase)
    {
        print("is called");
        switch (itemInteractedCase)
        {
            case 0:
                Debug.Log("You interacted with letter!");
                break;
            case 1:
                Debug.Log("You picked up an relic!");
                break;
        }
    }

    public InteractableConfig GetInteractableConfig()
    {
        return interactableConfig;
    }
}