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
    private float leftBorder = -10.0f;
    private float rightBorder = 10.0f;
    private float topBorder = 5.0f;
    private float bottomBorder = -5.0f;

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
        isInBounds();
    }

    void PlayerMoved() {
        float horizontalInput = Input.GetAxis("Horizontal");
        // Add velocity to the player based on the horizontal input and the player's move speed.
        rb.velocity = new Vector2(horizontalInput * playerMoveSpeed, rb.velocity.y);
    }

    void PlayerJumped() {
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.5f);
        //Debug.Log("Is the player grounded? " + isGrounded);

        // If the player hits the jump key, and the player is not already moving up or down, then add a jump velocity.
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f && isGrounded == true) {
            Vector2 jumpVelocity = new Vector2(0, playerJumpHeight);
            rb.velocity += jumpVelocity;
        }
    }

    void isInBounds() {
        // If the player goes out of bounds, then reset the player's position.
        if(transform.position.x < leftBorder || transform.position.x > rightBorder || transform.position.y < bottomBorder || transform.position.y > topBorder) {
            Debug.Log("Player was out of bounds.\nResetting player position.");
            transform.position = new Vector2(0, 0);
        }
    }
}
