using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityScreen : MonoBehaviour
{
    public List<Material> SecurityCamMats; 
    int camIndex = 0;
    MeshRenderer meshRenderer;

    void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();
    }


    public void CycleCam(int dir){
        camIndex += dir;
        if (camIndex >= SecurityCamMats.Count){
            camIndex = 0;
        }
        if (camIndex < 0){
            camIndex = SecurityCamMats.Count - 1;
        }
        meshRenderer.material = SecurityCamMats[camIndex];
    }
    
}
