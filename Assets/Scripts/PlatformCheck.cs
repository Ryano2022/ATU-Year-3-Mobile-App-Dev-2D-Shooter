using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheck : MonoBehaviour
{
    public GameObject touchScreenButtons;
    public GameObject keyboardControls;
    public int platform = 0;

    void Start() {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
            // If on mobile, enable touch controls.
            touchScreenButtons.SetActive(true);
            keyboardControls.SetActive(false);
            platform = 1;
        }
        else {
            // If not on mobile, disable touch controls.
            touchScreenButtons.SetActive(false);
            keyboardControls.SetActive(true);
            platform = 0;
        }
    }
}