using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // GameObject Prefab to fire from player weapon.
    private Transform firePoint;                          // Where to spawn projectile from.
    private Rigidbody2D rb;                               // Rigidbody2D component of the player.

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Fire a bullet when the player presses the Fire1 button.
        if (Input.GetButtonDown("Fire1")) {
            FireWeapon();
        }
    }

    private void FireWeapon() {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        rb.velocity = new Vector2(0, 0);
    }
}
