using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using TextMeshProUGUI;

public class Score : MonoBehaviour
{
    public Transform Player;
    // public Text scoreText;
public TextMeshProUGUI scoreText;

    void Update(){
            scoreText.text = "Score: " + (Player.position.x+4.71).ToString("0");
    }
}
