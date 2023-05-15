using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerLook : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] Transform playerHead;
    [SerializeField] Vector2 verticalClamp;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    float cameraPitch = 0.0f;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
   

    void Awake(){
        playerController = GetComponent<PlayerController>();
    }
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update(){
        Vector2 targetMouseDelta = Mouse.current.delta.ReadValue()*Time.smoothDeltaTime;
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        cameraPitch -= currentMouseDelta.y * PlayerSettings.ySensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, verticalClamp.x, verticalClamp.y);
        playerHead.localEulerAngles = Vector3.right * cameraPitch;
        playerController.transform.Rotate(Vector3.up * currentMouseDelta.x * PlayerSettings.xSensitivity);
    }
}
