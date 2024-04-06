using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  public float projectileLifeTime = 1f;

  // Start is called before the first frame update.
  void Start() {
    // Destroy the projectile after a certain amount of time.
    Destroy(gameObject, projectileLifeTime);
  }
}
