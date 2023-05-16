using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Mouse Settings")]
    [SerializeField] float xSensitivity;
    [SerializeField] float ySensitivity;

    [Header("Movement Settings")]
    [SerializeField] float mvtSpeed;

    [Header("Scripts and Objects")]
    [SerializeField] PlayerInteraction playerInteraction;
    [HideInInspector] public PlayerState playerState;
    Inputs inputs;

//

    void Awake(){
        inputs = new Inputs();
        playerState = PlayerState.Loading;
        PlayerSettings.SetVars(this, inputs, xSensitivity, ySensitivity, mvtSpeed);
    }
    void Start(){
        ToggleLook(true);
        ToggleMvt(true);
    }

//Toggle Stuff 
    public void ToggleMvt(bool b){
        GetComponent<PlayerMovement>().enabled = b;
        playerState = b ? PlayerState.Standing : PlayerState.Frozen;
    }

    public void ToggleLook(bool b){
        GetComponent<PlayerLook>().enabled = b;
    }

    public void Sit(){
        ToggleMvt(false);
        playerState = PlayerState.Sitting;
        //
        //TODO: Add animation to character cam
        //TODO: Add a way to get up from sitting
        //
    }

//

    void OnInteract(InputValue value){
        if (playerInteraction.currentInteractable != null){
            playerInteraction.currentInteractable.Interact();
        }
        
    }

 //

}
