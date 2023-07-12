using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour, IInteractable
{
    [SerializeField] string interactName;
    public string interactionName{
        get {return interactName;}
        set {interactName = value;}
    }

    public void Interact(){
        print("Vent");
    }

    
}
