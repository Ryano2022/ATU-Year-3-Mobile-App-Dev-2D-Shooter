using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheck : MonoBehaviour
{
    public GameObject touchScreenButtons;
    public GameObject keyboardControls;

    void Start() {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
            // If on mobile, enable touch controls.
            touchScreenButtons.SetActive(true);
            keyboardControls.SetActive(false);
        }
        else {
            // If not on mobile, disable touch controls.
            touchScreenButtons.SetActive(false);
            keyboardControls.SetActive(true);
        }
    }
}