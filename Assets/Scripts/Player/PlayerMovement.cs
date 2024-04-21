using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
    This script was partially written during a recording for the project.
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
    private float rightBorder = 50.0f;                              // The right world border of the game.
    private float topBorder = 5.0f;                                 // The top world border of the game.
    private float bottomBorder = -5.0f;                             // The bottom world border of the game.
    private SpriteRenderer srPlayer;                                // The sprite renderer component of the player.
    private SpriteRenderer srLeg;                                   // The sprite renderer component of the player's leg.
    private SpriteRenderer srWeapon;                                // The sprite renderer component of the player's weapon.
    private CameraMove cameraMove;                                  // The CameraMove script component.

    void Start() {
        // Get the Rigidbody2D component of the player.
        rb = GetComponent<Rigidbody2D>();

        // Get the SpriteRenderer component of the player.
        srPlayer = GetComponent<SpriteRenderer>();
        // Get the "Leg" child and its SpriteRenderer
        Transform legTransform = transform.Find("Leg");
        if (legTransform != null) {
            srLeg = legTransform.GetComponent<SpriteRenderer>();
            //Debug.Log("KBM - Leg found!");
        }
        // Get the "Weapon" child and its SpriteRenderer.
        Transform weaponTransform = transform.Find("Pistol");
        if (weaponTransform != null) {
            srWeapon = weaponTransform.GetComponent<SpriteRenderer>();
            //Debug.Log("KBM - Weapon found!");
        }
        srWeapon.enabled = false;

        // Get the CameraMove script component.
        cameraMove = GameObject.Find("Main Camera").GetComponent<CameraMove>();
    }

    void Update() {
        PlayerMove();
        PlayerJump();
        CheckIfInBounds();
    }

    void PlayerMove() {
        // Get the horizontal input from the player.
        movementInput = movementControls.action.ReadValue<Vector2>();
        //Debug.Log("Movement Input: " + movementInput);
        //if(movementInput.x != 0) {
        //    Debug.Log(CheckIfHitWall("left") + " | " + CheckIfHitWall("right"));
        //}
        
        // Check the direction of input.
        if (movementInput.x < 0 && CheckIfHitWall("left") != true || movementInput.x > 0 && CheckIfHitWall("right") != true) {
            rb.velocity = new Vector2(movementInput.x * playerMoveSpeed, rb.velocity.y);
            srPlayer.transform.localRotation = Quaternion.Euler(0, 0, 0);
        } 
        else if (Mathf.Abs(movementInput.x) < 0.01f) { 
            // Reduce the horizontal velocity by 20% each frame if no horizontal input is given.
            rb.velocity = new Vector2(rb.velocity.x * 0.8f, rb.velocity.y); 
        }

        if(movementInput.x > 0) {
            // Flip the player, the player's leg and the player's weapon to the RIGHT side.
            srPlayer.flipX = false;
            srLeg.flipX = false;
            srLeg.transform.localPosition = new Vector2(0.175f, -0.2f);
            srLeg.transform.localRotation = Quaternion.Euler(0, 0, 50);
            srWeapon.enabled = true;
            srWeapon.flipX = false;
            srWeapon.transform.localPosition = new Vector2(0.35f, -0.15f);
        } 
        else if(movementInput.x < 0) {
            // Flip the player, the player's leg and the player's weapon to the LEFT side.
            srPlayer.flipX = true;
            srLeg.flipX = true;
            srLeg.transform.localPosition = new Vector2(-0.175f, -0.2f);
            srLeg.transform.localRotation = Quaternion.Euler(0, 0, -50);
            srWeapon.enabled = true;
            srWeapon.flipX = true;
            srWeapon.transform.localPosition = new Vector2(-0.35f, -0.15f);
        }
    }

    void PlayerJump() {
        jumpInput = jumpControls.action.ReadValue<float>();
        //Debug.Log("Jump Input: " + jumpInput);
        
        // If the player hits the jump key, and the player is not already moving up or down, then add a jump velocity.
        if(jumpInput > 0 && Mathf.Abs(rb.velocity.y) < 0.001f) {
            Vector2 jumpVelocity = new Vector2(0, playerJumpHeight);
            rb.velocity += jumpVelocity;
        }
    }

    void CheckIfInBounds() {
        // If the player goes out of bounds, then reset the player's position.
        if(transform.position.x < leftBorder || transform.position.x > rightBorder || transform.position.y < bottomBorder || transform.position.y > topBorder) {
            Debug.Log("Player was out of bounds.\nResetting player position. ");
            transform.position = new Vector2(-8.5f, -1.25f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            cameraMove.ResetCameraPosition();
        }
    }

    public bool CheckIfHitWall(string direction) {
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
            //Debug.DrawRay(leftStartPos, Vector2.left * 0.1f, Color.red);
            result = hitLeft.collider != null;
        } 
        else if(direction == "right") {
            Vector2 rightStartPos = (Vector2)transform.position + Vector2.right * raycastOffset;
            RaycastHit2D hitRight = Physics2D.Raycast(rightStartPos, Vector2.right, 0.1f);
            //Debug.DrawRay(rightStartPos, Vector2.right * 1f, Color.red);
            result = hitRight.collider != null;
        }

        return result;
    }
}
