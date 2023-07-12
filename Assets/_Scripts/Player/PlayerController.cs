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
    public static Inputs inputs;


//

    void Awake(){
        animator = GetComponent<Animator>();
        officeControlls = GetComponent<OfficeControlls>();

        inputs = new Inputs();
        playerState = PlayerState.Loading;
        PlayerSettings.SetVars(this, xSensitivity, ySensitivity, mvtSpeed);
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

//Actions

    public void Sit(Transform t){
        officeControlls.enabled = true;
    
        animator.SetTrigger("Sit");
        transform.position = new Vector3(t.position.x, transform.position.y, t.position.z);

        playerInteraction.gameObject.SetActive(false);
        ToggleMvt(false);
        playerState = PlayerState.Sitting;
        
    }

    //This is called by an animation event in the standing animation
    public void StandUnlock(){
        
        ToggleMvt(true);
        playerInteraction.gameObject.SetActive(true);
    }
    

//Input Functions

    void OnInteract(InputValue value){
        if (playerState == PlayerState.Sitting){
            officeControlls.ToggleCams(false);
            animator.SetTrigger("Stand");
            officeControlls.enabled = false;
        }
        if (playerInteraction.currentInteractable.Count > 0 && playerInteraction.currentInteractable[0] != null){
            playerInteraction.currentInteractable[0].Interact();
        }
    }
    
    void OnEsc(InputValue value){
        //TODO: Add settings
    }

 

}
