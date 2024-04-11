using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/* 
    This script was written on video because of a requirement for the project.
    Help from my original script that was written during class.
    This script, however, has been heavily modified and improved upon since then.
*/

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerMoveSpeed = 3.0f;           // The player's movement speed.
    [SerializeField] public float playerJumpHeight = 4.5f;          // The player's jump height.
    [SerializeField] private InputActionReference movementControls; // The player's movement controls.
    [SerializeField] private InputActionReference jumpControls;     // The player's jump controls.
    private Vector2 movementInput;                                  // The player's movement vector.
    private float jumpInput;                                        // The player's jump input.
    public Rigidbody2D rb;                                          // Rigidbody2D component of the player.
    private float leftBorder = -10.0f;                              // The left world border of the game.
    private float rightBorder = 10.0f;                              // The right world border of the game.
    private float topBorder = 5.0f;                                 // The top world border of the game.
    private float bottomBorder = -5.0f;                             // The bottom world border of the game.
    private SpriteRenderer sr;                                      // The sprite renderer component of the player.
    private SpriteRenderer srLeg;                                   // The sprite renderer component of the player's weapon.

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // Get the "Leg" child and its SpriteRenderer
        Transform legTransform = transform.Find("Leg");
        if (legTransform != null) {
            srLeg = legTransform.GetComponent<SpriteRenderer>();
        }
    }

    void Update() {
        PlayerMoved();
        PlayerJumped();
        isInBounds();
    }

    public bool checkForWall(string direction) {
        direction = direction.ToLower();
        bool result = false;

        // Amount to offset the raycast by.
        float raycastOffset = 0.625f;

        if(direction == "left") {
            // The starting position of the raycast.
            Vector2 leftStartPos = (Vector2)transform.position + Vector2.left * raycastOffset;
            // The raycast hit information.
            RaycastHit2D hitLeft = Physics2D.Raycast(leftStartPos, Vector2.left, 0.1f);
            // Check if the player is touching a wall.
            result = hitLeft.collider != null;
        } 
        else if(direction == "right") {
            Vector2 rightStartPos = (Vector2)transform.position + Vector2.right * raycastOffset;
            RaycastHit2D hitRight = Physics2D.Raycast(rightStartPos, Vector2.right, 0.1f);
            result = hitRight.collider != null;
        }

        return result;
    }

    void PlayerMoved() {
        // Get the horizontal input from the player.
        movementInput = movementControls.action.ReadValue<Vector2>();
        //Debug.Log("Movement Input: " + movementInput);

        bool isTouchingWallLeft = checkForWall("left");
        bool isTouchingWallRight = checkForWall("right");
        
        // Check the direction of input and whether the player is touching a wall in that direction.
        if ((movementInput.x < 0 && !isTouchingWallLeft) || (movementInput.x > 0 && !isTouchingWallRight)) {
            rb.velocity = new Vector2(movementInput.x * playerMoveSpeed, rb.velocity.y);
        } 
        else if (Mathf.Abs(movementInput.x) < 0.01f) { 
            // Reduce the horizontal velocity by 10% each frame if no horizontal input is given.
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y); 
        }

        if(movementInput.x > 0) {
            sr.flipX = false;
            srLeg.flipX = false;
        } 
        else if(movementInput.x < 0) {
            sr.flipX = true;
            srLeg.flipX = true;            
        }
    }

    void PlayerJumped() {
        jumpInput = jumpControls.action.ReadValue<float>();
        //Debug.Log("Jump Input: " + jumpInput);
        
        // If the player hits the jump key, and the player is not already moving up or down, then add a jump velocity.
        if(jumpInput > 0 && Mathf.Abs(rb.velocity.y) < 0.001f) {
            Vector2 jumpVelocity = new Vector2(0, playerJumpHeight);
            rb.velocity += jumpVelocity;
        }
    }

    void isInBounds() {
        // If the player goes out of bounds, then reset the player's position.
        if(transform.position.x < leftBorder || transform.position.x > rightBorder || transform.position.y < bottomBorder || transform.position.y > topBorder) {
            Debug.Log("Player was out of bounds.\nResetting player position. ");
            transform.position = new Vector2(0, 0);
        }
    }
}
