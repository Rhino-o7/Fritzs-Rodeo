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

    //
    public PlayerState playerState;

    Inputs inputs;

    void Awake(){
        inputs = new Inputs();
        playerState = PlayerState.Loading;
        PlayerSettings.SetVars(this, inputs, xSensitivity, ySensitivity, mvtSpeed);
    }
    void Start(){
        ToggleLook(true);
        ToggleMvt(true);
    }

    public void ToggleMvt(bool b){
        if (b){
            inputs.Player.Move.Enable();
            playerState = PlayerState.Standing;
        }else{
            inputs.Player.Move.Disable();
            playerState = PlayerState.Frozen;
        }
    }

    public void ToggleLook(bool b){
        GetComponent<PlayerLook>().enabled = b;
    }

    public void Sit(){
        ToggleMvt(false);
        playerState = PlayerState.Sitting;
    }

 //

}
