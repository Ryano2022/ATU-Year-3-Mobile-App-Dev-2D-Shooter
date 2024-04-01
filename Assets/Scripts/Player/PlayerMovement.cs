using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
    This script was written on video because of a requirement for the project.
    Help from my original script that was written during class.
    This script, however, has been heavily modified and improved upon since then.
*/ 
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
        // Get the horizontal input from the player.
        float horizontalInput = Input.GetAxis("Horizontal");
        // Amount to offset the raycast by.
        float raycastOffset = 0.525f;
        // The starting position of the raycast.
        Vector2 leftStartPos = (Vector2)transform.position + Vector2.left * raycastOffset;
        Vector2 rightStartPos = (Vector2)transform.position + Vector2.right * raycastOffset;
        // The raycast hit information.
        RaycastHit2D hitLeft = Physics2D.Raycast(leftStartPos, Vector2.left, 0.65f);
        RaycastHit2D hitRight = Physics2D.Raycast(rightStartPos, Vector2.right, 0.65f);
        // Check if the player is touching a wall.
        bool isTouchingWallLeft = hitLeft.collider != null;
        bool isTouchingWallRight = hitRight.collider != null;
        // Draw the raycasts for debugging.
        /*
        Debug.DrawRay(leftStartPos, Vector2.left * 0.65f, Color.red);
        Debug.DrawRay(rightStartPos, Vector2.right * 0.65f, Color.red);
        Debug.Log("Left: " + isTouchingWallLeft + "\nRight: " + isTouchingWallRight);
        */

        // Check the direction of input and whether the player is touching a wall in that direction
        if ((horizontalInput < 0 && !isTouchingWallLeft) || (horizontalInput > 0 && !isTouchingWallRight)) {
            rb.velocity = new Vector2(horizontalInput * playerMoveSpeed, rb.velocity.y);
        }
    }

    void PlayerJumped() {
        // If the player hits the jump key, and the player is not already moving up or down, then add a jump velocity.
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) {
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
