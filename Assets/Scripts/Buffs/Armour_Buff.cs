using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour_Buff : MonoBehaviour
{
    private Armour_UI armourUI;
    private Lives_UI livesUI;

    void Start() {
        armourUI = GameObject.Find("Armour").GetComponent<Armour_UI>();
        livesUI = GameObject.Find("Lives").GetComponent<Lives_UI>();
    }

    // When the player collides with the armour buff object, activate the armour icon and destroy the buff.
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            ActivateArmourBuff();
            Destroy(gameObject, 0.25f);
        }
    }

    // Activate the armour buff.
    void ActivateArmourBuff() {
        livesUI.IncrementLifeCount();
        armourUI.ActivateArmourIcon();
    }
}
