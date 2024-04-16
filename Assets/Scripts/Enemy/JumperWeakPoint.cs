using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperWeakPoint : MonoBehaviour
{
    Collider2D weakPointCollider;     // CircleCollider2D component of the weak point.
    public bool hasBeenHit;          // Flag to check if the weak point has been hit.

    void Start() {
        // Get the CircleCollider2D component of the weak point.
        weakPointCollider = GetComponent<Collider2D>();
        hasBeenHit = false;
        //Debug.Log("Weak point collider: " + weakPointCollider.isTrigger);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // Check if the player has made contact with the trigger.
        if (collision.CompareTag("Player")) {
            // Destroy the parent object and all its children.
            Destroy(transform.parent.gameObject, 0.5f);
            hasBeenHit = true;
            Debug.Log("Player has hit the weak point. \nDestroyed the enemy.");
        }
    }
}
