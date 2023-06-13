using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OfficeControlls : MonoBehaviour
{
    [SerializeField] SecurityScreen securityScreen;
    bool camsOpen;
    PlayerController pc;
    UIManager ui;
    Inputs inputs;
    void Awake(){
        pc = PlayerSettings.pc;
        ui = UIManager.ui;
        inputs = PlayerController.inputs;
    }
    
    
    void OnToggleCams(InputValue value){
        if (this.isActiveAndEnabled && !camsOpen){// Open Cams
            //Anim
            ToggleCams(true);
            
        }else if (camsOpen){// Close Cams
            ToggleCams(false);
            
        }
    }
    public void ToggleCams(bool b){
        if (b){// Open

            // TODO: Anim

            inputs.Cams.Next.performed += NextCam;
            inputs.Cams.Back.performed += LastCam;
            
            camsOpen = true;
        }else{ // Close
            

            // TODO: Anim

            
            
            inputs.Cams.Next.performed -= NextCam;
            inputs.Cams.Back.performed -= LastCam;

            camsOpen = false;
        }
    }

    void NextCam(InputAction.CallbackContext _ct){
        securityScreen.CycleCam(1);
    }
    void LastCam(InputAction.CallbackContext _ct){
        securityScreen.CycleCam(-1);
    }

    void OnEnable(){
        inputs.Cams.Enable();
    }
    void OnDisable(){
        inputs.Cams.Disable();
    }



  
}
