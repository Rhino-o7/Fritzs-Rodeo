using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    UIManager ui;
    void Awake(){
        ui = UIManager.ui;
    }
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
        if (currentInteractable != null){
            ui.AddInteraction(currentInteractable.interactSprite);
        }
        
    }

    public void RemovePanel(bool removeCurrentInteractable){
        ui.RemoveInteraction();

        if (removeCurrentInteractable){
            currentInteractable = null;
        }
    }

    
}
