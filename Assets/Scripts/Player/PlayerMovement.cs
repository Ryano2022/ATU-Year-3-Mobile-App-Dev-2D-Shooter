using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was written on video because of a requirement for the project.
// Help from my original script that was written during class.
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed = 5.0f; // The speed of the player moving.
    [SerializeField] private float playerJumpHeight = 4.5f; // The height of the player's jump.
    private Rigidbody2D rb; // Reference to the player's Rigidbody2D component.

    // Start is called before the first frame update. 
    void Start() {
        // Grab the player's Rigidbody component.
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame.
    void Update() {
        // Check for these every frame.
        PlayerMoved();
        PlayerJumped();
    }

    void PlayerMoved() {
        float horizontalInput = Input.GetAxis("Horizontal");
        // Add velocity to the player based on the horizontal input and the player's move speed.
        rb.velocity = new Vector2(horizontalInput * playerMoveSpeed, rb.velocity.y);
    }

    void PlayerJumped() {
        // If the player hits the jump key, and the player is not already moving up or down, then add a jump velocity.
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) {
            Vector2 jumpVelocity = new Vector2(0, playerJumpHeight);
            rb.velocity += jumpVelocity;
        }
    }
}
