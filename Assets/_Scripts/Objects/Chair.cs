using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour, IInteractable
{
    PlayerController pc;
    public void Interact(){
        pc.Sit();
    }

    void OnTriggerEnter(Collider c){
        if(c.gameObject.TryGetComponent<PlayerController>(out pc)){
            //
            //TODO: Add panel to UI for a prompt to sit
            //TODO: Add UI script that executes the IInteractable for any IInteractable class
            //
            
            Debug.Log("Prompt To Sit");


        }
    }

    

    void OnTriggerExit(Collider c){
        if(c.gameObject.TryGetComponent<PlayerController>(out pc)){
            //
            //TODO: Remove sitting prompt from UI 
            //TODO: Remove this IInteractable 
            //

            Debug.Log("Remove Prompt To Sit");
        }
    }
}

    

