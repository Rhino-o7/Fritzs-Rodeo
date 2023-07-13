using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayItemHolder : MonoBehaviour
{
    private Vector3 vectOffset;
    private Transform cam;
    [SerializeField] float speed = 3f;

    void Start() {
        cam = Camera.main.transform;
        vectOffset = transform.position + cam.position;
    }

    void Update() {
        transform.position = cam.position + vectOffset;
        transform.rotation = Quaternion.Slerp(transform.rotation, cam.rotation, speed * Time.deltaTime);
    }
}
