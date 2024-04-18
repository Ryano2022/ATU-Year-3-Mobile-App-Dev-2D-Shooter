using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Armour_UI : MonoBehaviour
{
    private GameObject armourIcon;

    void Start() {
        armourIcon = GameObject.Find("Armour");
        armourIcon.SetActive(false);
    }

    // Activate the armour icon.
    public void ActivateArmourIcon() {
        armourIcon.SetActive(true);
    }

    // Deactivate the armour icon.
    public void DeactivateArmourIcon() {
        armourIcon.SetActive(false);
    }
}
