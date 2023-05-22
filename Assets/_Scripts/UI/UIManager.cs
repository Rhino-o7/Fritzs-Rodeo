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

    public void AddInteraction(Sprite interactionSprite){
        

        //TODO: Add UI elements with "InteractUI.cs"



    }
    public void RemoveInteraction(){
        

        //TODO: Remove UI elements

    }

    public void ToggleCams(bool b){
        camUI.gameObject.SetActive(b);


        //TODO: Add UI elements and cameras with "CamUI.cs"

    }

}
