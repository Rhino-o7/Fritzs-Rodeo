using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCam : MonoBehaviour
{
    [Header("Cam Will Turn to the Right From Scene Rotation")]
    [SerializeField] bool rotateCam;
    [SerializeField] float rotateAngle;
    [SerializeField] float rotateTime;
    [SerializeField] float pauseTime;
    float startAngle;
    void Awake(){
        startAngle = transform.localEulerAngles.y;
    }

    void Start(){
        if (rotateCam){
            StartCoroutine(Rotate(1));
        }
       
    }

    IEnumerator Rotate(int dir){//Direction is -1 or 1
        Quaternion rotation = transform.rotation;
        float moveTimer = 0f;
        float stopTimer = 0f;

        while (moveTimer < rotateTime){
            moveTimer += Time.deltaTime;
            transform.rotation = rotation * Quaternion.AngleAxis(moveTimer / rotateTime * rotateAngle * dir, Vector3.up);
            print("move");
            yield return null;
        }
        while (moveTimer >= rotateTime && stopTimer < pauseTime){
            stopTimer += Time.deltaTime;
            print("Stop");
            yield return null;
        }
        
        yield return(Rotate(-dir));

    }
}
