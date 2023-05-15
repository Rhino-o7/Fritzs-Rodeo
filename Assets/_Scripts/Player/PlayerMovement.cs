using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    Vector2 inputVector;
    Vector3 inputDir;


    void Awake(){
        cc = GetComponent<CharacterController>();
    }

    void Update(){
        float horizontal = inputVector.x;
        float vertical = inputVector.y;

        inputDir = Vector3.zero;
        inputDir += transform.forward * vertical * PlayerSettings.mvtSpeed * Time.deltaTime;
        inputDir += transform.right * horizontal * PlayerSettings.mvtSpeed * Time.deltaTime;
        inputDir += Physics.gravity;
        cc.Move(inputDir);
    }

    public void OnMove(InputValue value){
        inputVector = value.Get<Vector2>();
    }
}
