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

    Inputs inputs;

    void Awake(){
        inputs = new Inputs();
        PlayerSettings.SetVars(this, inputs, xSensitivity, ySensitivity, mvtSpeed);
    }
    void Start(){
        ToggleLook(true);
        ToggleMvt(true);
    }

    public void ToggleMvt(bool b){
        if (b){
            inputs.Player.Move.Enable();
        }else{
            inputs.Player.Move.Disable();
        }
    }

    public void ToggleLook(bool b){
        GetComponent<PlayerLook>().enabled = b;
    }

 //

}
