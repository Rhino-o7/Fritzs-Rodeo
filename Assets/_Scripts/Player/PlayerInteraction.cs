using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    UIManager ui;
    public List<IInteractable> currentInteractable;
    void Awake(){
        ui = UIManager.ui;
        currentInteractable = new List<IInteractable>();
    }
    

    void OnTriggerEnter(Collider c){
        IInteractable _tempInteract;
        if (c.TryGetComponent<IInteractable>(out _tempInteract)){
            
            if (currentInteractable.Contains(_tempInteract)){
                currentInteractable.Remove(_tempInteract);
            }
            currentInteractable.Insert(0, _tempInteract);
            ui.AddInteraction(_tempInteract);
        }
    }

    void OnTriggerExit(Collider c){
        IInteractable _tempInteract = c.GetComponent<IInteractable>();
        if (_tempInteract != null && currentInteractable.Contains(_tempInteract)){
            currentInteractable.Remove(_tempInteract);
        }
        if (currentInteractable.Count == 0){
            ui.RemoveInteraction();
        }else{
            ui.AddInteraction(currentInteractable[0]);
        }
        
    }


    void OnEnable(){
        if (currentInteractable.Count > 0){
            ui.AddInteraction(currentInteractable[0]);
        }
    }

    void OnDisable(){
        ui.RemoveInteraction();
    }


    
    
}
