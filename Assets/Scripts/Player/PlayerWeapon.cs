using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private InputActionReference attack;           // The player's attack controls.
    [SerializeField] private Projectile projectileParent;           // The projectile prefab.
    [SerializeField] private float projectileSpeed = 20f;           // The speed of the projectile.
    [SerializeField] private float fireRate = 0.1f;                 // The rate of fire.  
    private Coroutine firingCoroutine;                              // The coroutine for firing the projectile.
    public int facingDirection = 1;                                 // The direction the player is facing.
    PlatformCheck platformCheck;                                    // Reference to the PlatformCheck script.


    void Start() {
        platformCheck = GameObject.Find("Input Buttons").GetComponent<PlatformCheck>();
    }

    // Coroutine returns an IEnumerator type.
    private IEnumerator FireCoroutine() {
        while (true) {
            if(platformCheck.platform == 0) {
                // If the player is looking right, set the direction to face right.
                if (Input.GetAxis("Horizontal") > 0) {
                    facingDirection = 1;
                }

                // If the player is looking left, set the direction to face left.
                if (Input.GetAxis("Horizontal") < 0) {
                    facingDirection = -1;
                }
            }

            // Set the spawn position of the bullet to be in front of the player.
            Vector2 spawnPosition = new Vector2(transform.position.x + 0.7f * facingDirection, transform.position.y - 0.2f);

            // Instantiate bullet here, set velocity and then sleep for short time.
            Projectile bullet = Instantiate(projectileParent, spawnPosition, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (facingDirection == 1) {
                rb.velocity = Vector2.right * projectileSpeed;
            }
            else {
                rb.velocity = Vector2.left * projectileSpeed;
            }

            yield return new WaitForSeconds(fireRate);
        }
    }

    private void OnEnable() {
        attack.action.started += Attack_started;
        attack.action.performed += Attack_performed;
        attack.action.canceled += Attack_canceled;
    }

    // Callbacks for the attack action.
    // Started is called when the button is first pressed.
    private void Attack_started(InputAction.CallbackContext obj) {
        firingCoroutine = StartCoroutine(FireCoroutine());
    }

    // Performed is called every frame the button is held down.
    private void Attack_performed(InputAction.CallbackContext obj) { }

    // Canceled is called when the button is released.
    private void Attack_canceled(InputAction.CallbackContext obj) {
        StopCoroutine(firingCoroutine);
    }

    private void OnDisable() {
        attack.action.started -= Attack_started;
        attack.action.performed -= Attack_performed;
        attack.action.canceled -= Attack_canceled;
    }

    public void TSStartFiring() {
        firingCoroutine = StartCoroutine(FireCoroutine());
    }

    public void TSStopFiring() {
        StopCoroutine(firingCoroutine);
    }
}