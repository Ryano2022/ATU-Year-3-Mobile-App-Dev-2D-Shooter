using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJumpBehaviour : MonoBehaviour
{
    Collider2D jumpCollider;                                // CapsuleCollider2D component of the jump trigger.
    [SerializeField] private float enemyJumpHeight = 3.5f;  // The enemy's jump height.

    void Start() {
        // Get the CapsuleCollider2D component of the jump trigger.
        jumpCollider = GetComponent<Collider2D>();
        //Debug.Log("Jump collider: " + jumpCollider.isTrigger);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // Check if the player has made contact with the trigger.
        if (collision.CompareTag("Player")) {
            // Get the Rigidbody2D component of the enemy.
            Rigidbody2D rb = transform.parent.GetComponent<Rigidbody2D>();
            // Add a force to the enemy to make it jump.
            if(Mathf.Abs(rb.velocity.y) < 0.001f) {
                Vector2 jumpVelocity = new Vector2(0, enemyJumpHeight);
                rb.velocity += jumpVelocity;
            }
            Debug.Log("Player has hit the jump trigger. \nEnemy has jumped.");
        }
    }
}
