using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OfficeControlls : MonoBehaviour
{
    bool camsOpen;
    public bool isEnabled;
    PlayerController pc;
    UIManager ui;
    void Awake(){
        pc = PlayerSettings.pc;
        ui = UIManager.ui;
    }
    
    
    void OnToggleCams(InputValue value){
        if (isEnabled){
            camsOpen = !camsOpen;
            pc.ToggleLook(!camsOpen);
            ui.ToggleCams(camsOpen);

        }

    }

    void OnEnable(){
        isEnabled = true;
    }
    void OnDisable(){
        isEnabled = false;
        //Check if cams open
        if (camsOpen){
            ui.ToggleCams(false);
            pc.ToggleLook(true);
            

        }
        
    }
}
