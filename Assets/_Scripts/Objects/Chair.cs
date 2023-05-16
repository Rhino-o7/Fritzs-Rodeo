using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour, IInteractable
{
    PlayerController pc;
    void Awake(){
        pc = PlayerSettings.pc;
    }
    public void Interact(){
        pc.Sit();
    }
}
    

