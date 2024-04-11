using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTSMovement : MonoBehaviour
{
    public PlayerMovement playerMovement;         // Reference to the PlayerMovement script.
    private Rigidbody2D rb;                       // Rigidbody2D component of the player.
    private bool movingLeft;                      // Is the player moving left?
    private bool movingRight;                     // Is the player moving right?                      
    private SpriteRenderer sr;                    // The sprite renderer component of the player.
    public SpriteRenderer srLeg;                  // The sprite renderer component of the player's leg.
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // Get the "Leg" child and its SpriteRenderer
        Transform legTransform = transform.Find("Leg");
        if (legTransform != null) {
            srLeg = legTransform.GetComponent<SpriteRenderer>();
        }

        movingLeft = false;
        movingRight = false;
    }

    void Update() {
        if (movingLeft == true) {
            tsMoveLeft();
        }
        if (movingRight == true) {
            tsMoveRight();
        }
    }

    // Touch screen left movement button.
    public void tsMoveLeft() {
        bool isTouchingWallLeft = playerMovement.checkForWall("left");

        if (!isTouchingWallLeft) {
            rb.velocity = new Vector2(-playerMovement.playerMoveSpeed, rb.velocity.y);
            sr.flipX = true;
            srLeg.flipX = true;  
        }
    }

    // Touch screen right movement button.
    public void tsMoveRight() {
        bool isTouchingWallRight = playerMovement.checkForWall("right");

        if (!isTouchingWallRight && movingRight == true) {
            rb.velocity = new Vector2(playerMovement.playerMoveSpeed, rb.velocity.y);
            sr.flipX = false;
            srLeg.flipX = false;  
        }
    }

    // Touch screen jump button.
    public void tsJump() {
        if (Mathf.Abs(rb.velocity.y) < 0.001f) {
            Vector2 jumpVelocity = new Vector2(0, playerMovement.playerJumpHeight);
            rb.velocity += jumpVelocity;
        }
    }

    public void StartMovingLeft() {
        movingLeft = true;
    }

    public void StopMovingLeft() {
        movingLeft = false;
    }

    public void StartMovingRight() {
        movingRight = true;
    }

    public void StopMovingRight() {
        movingRight = false;
    }
}
