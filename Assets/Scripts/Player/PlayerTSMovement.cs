using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTSMovement : MonoBehaviour
{
    public PlayerMovement playerMovement;         // Reference to the PlayerMovement script.
    private Rigidbody2D rb;                       // Rigidbody2D component of the player.
    private bool movingLeft;                      // Is the player moving left?
    private bool movingRight;                     // Is the player moving right?                      
    private SpriteRenderer srPlayer;              // The sprite renderer component of the player.
    private SpriteRenderer srLeg;                  // The sprite renderer component of the player's leg.
    private SpriteRenderer srWeapon;              // The sprite renderer component of the player's weapon.
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        srPlayer = GetComponent<SpriteRenderer>();

        // Get the "Leg" child and its SpriteRenderer
        Transform legTransform = transform.Find("Leg");
        if (legTransform != null) {
            srLeg = legTransform.GetComponent<SpriteRenderer>();
            Debug.Log("TS - Leg found!");
        }

        // Get the "Weapon" child and its SpriteRenderer.
        Transform weaponTransform = transform.Find("Pistol");
        if (weaponTransform != null) {
            srWeapon = weaponTransform.GetComponent<SpriteRenderer>();
            Debug.Log("TS - Weapon found!");
        }

        movingLeft = false;
        movingRight = false;
    }

    void Update() {
        if (movingLeft == true) {
            TSPlayerMoveLeft();
        }
        if (movingRight == true) {
            TSPlayerMoveRight();
        }
    }

    // Touch screen left movement button.
    public void TSPlayerMoveLeft() {
        bool isTouchingWallLeft = playerMovement.CheckIfHitWall("left");

        if (!isTouchingWallLeft) {
            rb.velocity = new Vector2(-playerMovement.playerMoveSpeed, rb.velocity.y);
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

    // Touch screen right movement button.
    public void TSPlayerMoveRight() {
        bool isTouchingWallRight = playerMovement.CheckIfHitWall("right");

        if (!isTouchingWallRight && movingRight == true) {
            rb.velocity = new Vector2(playerMovement.playerMoveSpeed, rb.velocity.y);
            // Flip the player, the player's leg and the player's weapon to the RIGHT side.
            srPlayer.flipX = false;
            srLeg.flipX = false;
            srLeg.transform.localPosition = new Vector2(0.175f, -0.2f);
            srLeg.transform.localRotation = Quaternion.Euler(0, 0, 50);
            srWeapon.enabled = true;
            srWeapon.flipX = false;
            srWeapon.transform.localPosition = new Vector2(0.35f, -0.15f);
        }
    }

    // Touch screen jump button.
    public void TSPlayerJump() {
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
