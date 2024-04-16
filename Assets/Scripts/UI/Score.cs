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
    }

    public void IncrementScore(int scoreToAdd) {
        score += scoreToAdd;
        UpdateScore();
    }

    public void DecrementScore(int scoreToSubtract) {
        score -= scoreToSubtract;
        UpdateScore();
    }

    public void ResetScore() {
        score = 0;
        UpdateScore();
    }
}
