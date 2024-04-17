using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Loads the relevent scene when the button is pressed.

    public void PlayButton() {
        Debug.Log("Play button pressed. ");
        SceneManager.LoadScene("Level 01");
        Debug.Log("Loaded scene: Level 01 ");
    }

    public void TutorialButton() {
        Debug.Log("Tutorial button pressed. ");
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Loaded scene: Tutorial ");
    }

    public void PreferencesButton() {
        Debug.Log("Preferences button pressed. ");
        SceneManager.LoadScene("Preferences");
        Debug.Log("Loaded scene: Preferences ");
    }

    public void MainMenuButton() {
        Debug.Log("Main Menu button pressed. ");
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Loaded scene: Main Menu ");
    }
}
