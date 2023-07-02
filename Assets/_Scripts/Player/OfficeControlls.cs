using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OfficeControlls : MonoBehaviour
{
    [SerializeField] SecurityScreen securityScreen;
    [SerializeField] GameObject doors;
    bool camsOpen;
    PlayerController pc;
    UIManager ui;
    Inputs inputs;
    Animator lDoor;
    Animator rDoor;
    void Awake(){
        pc = PlayerSettings.pc;
        ui = UIManager.ui;
        inputs = PlayerController.inputs;
        if (doors){
            rDoor = doors.transform.GetChild(0).GetComponent<Animator>();
            lDoor = doors.transform.GetChild(1).GetComponent<Animator>();
        }
        
        

    }
    
    public void ToggleCams(bool b){
        if (b){// Open

            // TODO: Animation

            inputs.Cams.Next.performed += NextCam;
            inputs.Cams.Back.performed += LastCam;
            
            camsOpen = true;
        }else{ // Close
            

            // TODO: Animation

            inputs.Cams.Next.performed -= NextCam;
            inputs.Cams.Back.performed -= LastCam;

            camsOpen = false;
        }
    }
    void ToggleCams(InputAction.CallbackContext _ct){
        if (camsOpen == true){
            ToggleCams(false);
        }else{
            ToggleCams(true);
        }
    }

    void NextCam(InputAction.CallbackContext _ct){
        if (securityScreen){
            securityScreen.CycleCam(1);
        }
    }
    void LastCam(InputAction.CallbackContext _ct){
        if (securityScreen){
            securityScreen.CycleCam(-1);
        }
    }

    void LeftDoor(InputAction.CallbackContext _ct){
        lDoor.SetTrigger("Activate");
        lDoor.SetBool("Up", !lDoor.GetBool("Up"));
        
    }
    void RightDoor(InputAction.CallbackContext _ct){
        
        rDoor.SetTrigger("Activate");
        rDoor.SetBool("Up", !rDoor.GetBool("Up"));
        
    }

    void Blackout(InputAction.CallbackContext _ct){
        print("Blackout");
    }


    void OnEnable(){
        inputs.Cams.Enable();
        inputs.Office.Enable();
        inputs.Office.DoorL.performed += LeftDoor;
        inputs.Office.DoorR.performed += RightDoor;
        inputs.Office.Blackout.performed += Blackout;
        inputs.Office.ToggleCams.performed += ToggleCams;


        print("enable");
    }
    void OnDisable(){
        inputs.Office.DoorL.performed -= LeftDoor;
        inputs.Office.DoorR.performed -= RightDoor;
        inputs.Office.Blackout.performed -= Blackout;
        inputs.Office.ToggleCams.performed -= ToggleCams;
        inputs.Cams.Disable();
        inputs.Office.Disable();
        print("Disable");
    }



  
}
