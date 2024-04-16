using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float enemyJumpHeight = 3.0f;
    Rigidbody2D rb;
    BoxCollider2D weakPointTrigger;
    BoxCollider2D behaviourTrigger;

    void Start() {
        rb = GetComponent<Rigidbody2D>();

        // Get the trigger components.
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

        if (colliders.Length > 1) {
            weakPointTrigger = colliders[0];
            behaviourTrigger = colliders[1];

            //Debug.Log(weakPointTrigger.bounds.size.y + " Head Trigger");
            //Debug.Log(behaviourTrigger.bounds.size.y + " Jump Trigger");
        } 
        else {
            Debug.Log("Not enough BoxCollider2D components on enemy!");
        }
    }

    void Update() {
        EnemyJump();
    }

    void EnemyJump() {
        if(Mathf.Abs(rb.velocity.y) < 0.001f) {
            Vector2 jumpVelocity = new Vector2(0, enemyJumpHeight);
            rb.velocity += jumpVelocity;
        }
    }
}
