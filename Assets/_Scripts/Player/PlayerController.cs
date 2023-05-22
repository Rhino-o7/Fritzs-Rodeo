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
    
    public PlayerState playerState;

    OfficeControlls officeControlls;
    Animator animator;
    Inputs inputs;

//

    void Awake(){
        animator = GetComponent<Animator>();
        officeControlls = GetComponent<OfficeControlls>();

        inputs = new Inputs();
        playerState = PlayerState.Loading;
        PlayerSettings.SetVars(this, inputs, xSensitivity, ySensitivity, mvtSpeed);
    }
    void Start(){
        officeControlls.enabled = false;
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
    public void ToggleInteraction(bool b){
        playerInteraction.enabled = b;
    }

//Actions

    public void Sit(Transform t){
        officeControlls.enabled = true;
        playerInteraction.RemovePanel(false);
        animator.SetTrigger("Sit");
        transform.position = new Vector3(t.position.x, transform.position.y, t.position.z);


        ToggleMvt(false);
        ToggleInteraction(false);
        playerState = PlayerState.Sitting;
        
    }

    //This is called by an animation event in the standing animation
    public void StandUnlock(){
        
        officeControlls.enabled = false;
        ToggleMvt(true);
        ToggleInteraction(true);
        playerInteraction.AddPanel();
    }
    

//Input Functions

    void OnInteract(InputValue value){
        if (playerInteraction.currentInteractable != null){
            playerInteraction.currentInteractable.Interact();
        }
        
    }
    void OnEsc(InputValue value){
    //Switch from sitting to standing
    //Note: may want to change to a different key than ESC
        if (playerState == PlayerState.Sitting){
            animator.SetTrigger("Stand");
        }
    }

 //

}
