using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0; // The player's score.
    GameObject scoreText; // The score text object.

    void Start() {
        scoreText = GameObject.Find("Score Text");
        UpdateScore();
    }
    
    void UpdateScore() {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score;
        Debug.Log("Score has been updated.");
    }

    public void IncrementScore(int scoreToAdd) {
        score += scoreToAdd;
        Debug.Log("Score has been incremented by " + scoreToAdd + ".\nCurrent score: " + score);
        UpdateScore();
    }

    public void DecrementScore(int scoreToSubtract) {
        score -= scoreToSubtract;
        Debug.Log("Score has been decremented by " + scoreToSubtract + ".\nCurrent score: " + score);
        UpdateScore();
    }

    public void ResetScore() {
        score = 0;
        Debug.Log("Score has been reset.");
        UpdateScore();
    }
}
