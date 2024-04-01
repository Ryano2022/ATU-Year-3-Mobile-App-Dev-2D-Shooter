using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationLock : MonoBehaviour
{
    // Lock the camera's rotation.
    void Update() {
        transform.rotation = Quaternion.identity;
    }
}
