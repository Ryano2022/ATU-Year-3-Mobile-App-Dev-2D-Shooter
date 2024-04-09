using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTSMovement : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private Rigidbody2D rb;
    private bool movingLeft;
    private bool movingRight;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
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
            rb.velocity = new Vector2(-(playerMovement.playerMoveSpeed / 2), rb.velocity.y);
        }
    }

    // Touch screen right movement button.
    public void tsMoveRight() {
        bool isTouchingWallRight = playerMovement.checkForWall("right");

        if (!isTouchingWallRight && movingRight == true) {
            rb.velocity = new Vector2(playerMovement.playerMoveSpeed / 2, rb.velocity.y);
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
