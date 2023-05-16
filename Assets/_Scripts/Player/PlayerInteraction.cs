using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] UIManager UI;
    public IInteractable currentInteractable;
    void OnTriggerEnter(Collider c){
        if (c.TryGetComponent<IInteractable>(out currentInteractable)){
            //
            //TODO: Add panel to UI for a prompt to sit
            //
            print(currentInteractable);
        }
    }

    void OnTriggerExit(Collider c){
        if (c.TryGetComponent<IInteractable>(out currentInteractable)){
            //
            //TODO: Remove sitting prompt from UI 
            //
            currentInteractable = null;
            print(currentInteractable);
        }
    }

    
}
