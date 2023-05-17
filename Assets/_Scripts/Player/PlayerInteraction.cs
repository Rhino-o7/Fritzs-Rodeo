using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] UIManager UI;
    public IInteractable currentInteractable;
    void OnTriggerEnter(Collider c){
        if (currentInteractable == null && c.TryGetComponent<IInteractable>(out currentInteractable)){ 
            AddPanel();
        }
    }

    void OnTriggerExit(Collider c){
        if (c.TryGetComponent<IInteractable>(out currentInteractable)){
            RemovePanel(true);
        }
    }

    public void AddPanel(){
        print("Add " + currentInteractable + " Panel");

        //TODO: Add panel to UI for interaction prompts using "UIManager" class
        
    }

    public void RemovePanel(bool removeCurrentInteractable){
        print("Rmove " + currentInteractable + " Panel");
        
        //TODO: remove panel to UI for interaction prompts

        if (removeCurrentInteractable){
            currentInteractable = null;
        }
    }

    
}
