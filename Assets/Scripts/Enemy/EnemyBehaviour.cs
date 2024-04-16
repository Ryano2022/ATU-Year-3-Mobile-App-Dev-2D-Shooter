using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D rb;                        // Rigidbody2D component of the enemy.
    private float leftBorder = -10.0f;     // The left world border of the game.
    private float rightBorder = 10.0f;     // The right world border of the game.
    private float topBorder = 5.0f;        // The top world border of the game.
    private float bottomBorder = -5.0f;    // The bottom world border of the game.

    BoxCollider2D enemyCollider;           // BoxCollider2D component of the enemy.
    JumperWeakPoint weakPoint;             // JumperWeakPoint script component of the enemy.
    Lives lives;                           // Lives script component of the enemy.
    int health = 3;                        // The enemy's health.

    void Start() {
        rb = GetComponent<Rigidbody2D>();

        // Get the BoxCollider2D component of the enemy.
        enemyCollider = GetComponent<BoxCollider2D>();

        // Get the JumperWeakPoint script component of the enemy.
        weakPoint = GetComponentInChildren<JumperWeakPoint>();
        weakPoint.hasBeenHit = false;

        // Get the Lives script component of the enemy.
        lives = GameObject.Find("Lives").GetComponent<Lives>();
    }

    void Update() {
        CheckIfInBounds();        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // Check if the enemy has collided with the player.
        if (collision.gameObject.CompareTag("Player") && !weakPoint.hasBeenHit) {
            // Respawn the player at the 0,0 point.
            collision.gameObject.transform.position = new Vector2(0, 0);
            Debug.Log("Player has collided with the enemy.\nRespawning the player.");
            lives.DecrementLifeCount();
        }
        else if(collision.gameObject.CompareTag("Bullet")) {
            // Destroy the bullet.
            Destroy(collision.gameObject);

            // Reduce the enemy's speed from being hit by a bullet.
            rb.velocity *= 0.1f;

            // Reduce the enemy's health.
            health--;
            Debug.Log("Enemy has been hit by a bullet.\nHealth: " + health + "/3");

            // If the enemy's health is 0, then destroy the enemy.  
            if(health <= 0) {
                Destroy(gameObject);
                Debug.Log("Enemy has been destroyed.");
            }
        }
    }

    void CheckIfInBounds() {
        // If the enemy goes out of bounds, then destroy the enemy.
        if(transform.position.x < leftBorder || transform.position.x > rightBorder || transform.position.y < bottomBorder || transform.position.y > topBorder) {
            Debug.Log("Enemy was out of bounds.\nDestroying the enemy. ");
            Destroy(gameObject);
        }
    }
}
