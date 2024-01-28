using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    void OnEnable(){
        PlayerHealth.OnPlayerDeath += EnableGameOverMenu;
    }
    void OnDisable(){
        PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
    }
    public void EnableGameOverMenu(){
        gameOverMenu.SetActive(true);
    }
    public void RestartLevel(){
        // SceneManager.LoadScene("SampleScene");
        Debug.Log("buttonClicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void LoadMenu(){
        SceneManager.LoadScene("MainMenu");

    }
}
