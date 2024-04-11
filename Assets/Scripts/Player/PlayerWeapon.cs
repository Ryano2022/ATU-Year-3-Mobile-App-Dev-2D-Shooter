using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private InputActionReference attack;
    [SerializeField] private Projectile projectileParent;
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private float fireRate = 0.1f;
    private Coroutine firingCoroutine;
    private int facingDirection = 1;

    // Coroutine returns an IEnumerator type.
    private IEnumerator FireCoroutine() {
        while (true) {
            // If the player is looking right, instantiate the bullet and set its velocity to move right.
            if (Input.GetAxis("Horizontal") > 0) {
                facingDirection = 1;
            }

            // If the player is looking left, instantiate the bullet and set its velocity to move left.
            if (Input.GetAxis("Horizontal") < 0) {
                facingDirection = -1;
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
}