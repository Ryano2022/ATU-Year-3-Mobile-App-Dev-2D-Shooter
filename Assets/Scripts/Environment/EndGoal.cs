using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Load the next scene if there is one, otherwise load the main menu.
        if (other.gameObject.CompareTag("Player")) {
            int nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneBuildIndex < SceneManager.sceneCountInBuildSettings) {
                Debug.Log("Loading next level.\nScene index: " + nextSceneBuildIndex);
                SceneManager.LoadScene(nextSceneBuildIndex);
            }
            else {
                Debug.Log("No more levels to load, returning to main menu.\nScene index: 0");
                SceneManager.LoadScene(0);
            }
        }
    }
}
