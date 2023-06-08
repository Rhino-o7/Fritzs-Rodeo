using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static UIManager ui;
    [SerializeField] CamUI camUI;
    [SerializeField] InteractUI interactUI;
    
    void Awake(){
        ui = this;
        
    }
    
    IEnumerator Start(){// Wait until fist frame to render UI and then disable to avoid lag spike
        interactUI.gameObject.SetActive(true);
        camUI.gameObject.SetActive(true);
        yield return 0;
        interactUI.gameObject.SetActive(false);
        camUI.gameObject.SetActive(false);

    }

    public void AddInteraction(IInteractable interactable){
        if (!interactUI.gameObject.activeSelf){
            interactUI.gameObject.SetActive(true);
        }
        
        interactUI.interactTxt.text = interactable.interactionName;

    }
    public void RemoveInteraction(){
        if (interactUI){
            interactUI.interactTxt.text = "";
            interactUI.gameObject.SetActive(false);
        }
        
    }

    public void ToggleCams(bool b){
        camUI.gameObject.SetActive(b);


        //TODO: Add UI elements and cameras with "CamUI.cs"

    }

}
