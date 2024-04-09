using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  public float projectileLifeTime = 1f;

  void Start() {
    // Destroy the projectile after a certain amount of time.
    Destroy(gameObject, projectileLifeTime);
  }
}
