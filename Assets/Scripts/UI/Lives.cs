using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] private Image[] livesIcons;
    int maxLives = 3; // The maximum number of lives the player can have.
    int currentLives = 3; // The current number of lives the player has.

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

    // Decrease the number of lives by 1.
    public void DecrementLifeCount() {
        currentLives--;
        UpdateIcons(currentLives);

        // If the player has no more lives, then the game is over.
        if(currentLives <= 0) {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("Main Menu");
        }
    }
}
