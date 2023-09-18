using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using TextMeshProUGUI;

public class Score : MonoBehaviour
{
    public Transform Player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    int Scores = 0;
    void Start()
    {
        UpdateHighScoreText();
    }
    void Update()
    {
        Scores = (int)Player.position.x + (int)4.71;
        scoreText.text = "Score: " + (Player.position.x + 4.71).ToString("0");
        CheckHighScore();
    }
    void CheckHighScore()
    {
        if (Player.position.x + 4.71 > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Scores);
            UpdateHighScoreText();
        }
    }
    void UpdateHighScoreText()
    {
        highscoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", Scores)}";
    }
}
