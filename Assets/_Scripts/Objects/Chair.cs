using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour, IInteractable
{
    [SerializeField] Sprite interactableSprite;
    public Sprite interactSprite{
        get {return interactableSprite;}
        set {interactableSprite = value;}
    }
    PlayerController pc;
    

    void Awake(){
        pc = PlayerSettings.pc;
        interactSprite = interactableSprite;
    }
    public void Interact(){
        pc.Sit(transform);
    }

   
}
    

