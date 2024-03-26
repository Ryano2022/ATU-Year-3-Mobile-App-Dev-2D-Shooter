using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] private Image[] livesIcons;
    int maxLives = 3; // The maximum number of lives the player can have.

    // Start is called before the first frame update.
    void Start() {
        // Initially, all lives icons are active.
        UpdateIcons(maxLives);
    }

    // Update the lives icons based on the current number of lives.
    public void UpdateIcons(int currentLives) {
        if(currentLives < maxLives) {
            livesIcons[currentLives].gameObject.SetActive(false);
        }
    }
}
