using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform cameraTransform;
    void Start() {
        cameraTransform = FindObjectOfType<Camera>().transform;
    }

    void Update() {
        // Move the camera to the right.
        cameraTransform.position += new Vector3(0.0125f, 0f);
    }

    public void ResetCameraPosition() {
        cameraTransform.position = new Vector3(0, 0, -10);
    }
}
