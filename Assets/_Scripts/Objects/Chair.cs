using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour, IInteractable
{
    [SerializeField] string interactName;
    
    public string interactionName{
        get {return interactName;}
        set {interactName = value;}
    }
    PlayerController pc;
    

    void Awake(){
        pc = PlayerSettings.pc;
        
    }
    public void Interact(){
        pc.Sit(transform);
    }

   
}
    

