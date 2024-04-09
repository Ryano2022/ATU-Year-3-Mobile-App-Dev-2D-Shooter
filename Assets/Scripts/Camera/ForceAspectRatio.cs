using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class AspectRatioEnforcer : MonoBehaviour
{
    public Vector2 targetAspect = new Vector2(16, 9);
    Camera cam;

    void Awake() {
        cam = GetComponent<Camera>();
    }

    void Update() {
        float targetRatio = targetAspect.x / targetAspect.y;
        float currentRatio = (float)Screen.width / (float)Screen.height;

        if (currentRatio < targetRatio)
        {
            float ratioDifference = targetRatio / currentRatio;
            cam.orthographicSize = cam.orthographicSize * ratioDifference;
        }
    }
}