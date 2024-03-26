using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference IA_Ref;       // Input action for movement.
    private Rigidbody2D rb;                                     // Reference to the player's Rigidbody2D component.
    private Vector2 movementInput;                              // The current movement input.
    private Vector2 savedMoveInput;                             // The last non-zero movement input.
    private float currentSpeed;                                 // The current speed of the player.
    [SerializeField] private float maxSpeed = 5;                // The maximum speed of the player.
    [SerializeField] private float acceleration = 0.5f;         // The acceleration of the player.
    [SerializeField] private float deceleration = 0.5f;         // The deceleration of the player.

    // Start is called before the first frame update.
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame.
    private void Update() {
        movementInput = IA_Ref.action.ReadValue<Vector2>();  
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate.
    void FixedUpdate() {
        if(movementInput.magnitude > 0) {
            savedMoveInput = movementInput;
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;
        }
        else {
            currentSpeed -= deceleration * maxSpeed * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb.velocity = savedMoveInput * currentSpeed;
    }
}
