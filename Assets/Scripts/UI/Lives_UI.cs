using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives_UI : MonoBehaviour
{
    [SerializeField] private Image[] livesIcons;    // The array of lives icons.
    private Armour_UI armourUI;                     // The Armour_UI script.
    private int maxLives = 3;                       // The maximum number of lives the player can have.
    private int currentLives = 3;                   // The current number of lives the player has.


    void Start() {
        // if(SceneManager.GetActiveScene().buildIndex == 3) {
        //     GameObject canvas = GameObject.Find("Canvas");
        //     Transform icons = canvas.transform.Find("Icons");
        //     Transform powerUps = icons.transform.Find("Power Ups");
        //     armourUI = powerUps.transform.Find("Armour").GetComponent<Armour_UI>();
        // }
        // Debug.Log(armourUI);

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
        // // If the armour icon is active, deactivate it and return.
        // if(SceneManager.GetActiveScene().buildIndex == 3) {
        //     if(armourUI.isActiveAndEnabled == true) {
        //         armourUI.DeactivateArmourIcon();
        //         return;
        //     }
        // }

        currentLives--;
        UpdateIcons(currentLives);

        // If the player has no more lives, then the game is over.
        if(currentLives <= 0) {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("Main Menu"); // Placeholder
        }
    }

    // Increase the number of lives by 1.
    public void IncrementLifeCount() {
        currentLives++;
        UpdateIcons(currentLives);
    }
}
