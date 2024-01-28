using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu1 : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    void Update(){
     if (Input.GetButtonDown("Cancel"))
        {      
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }}

    public void Resume(){
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        Cursor.visible = false;
       
    }
    public void Pause(){
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;

    } 
    public void mainMenu(){
        Time.timeScale = 1f;
       Cursor.lockState = CursorLockMode.None;
        isPaused = false;
       Cursor.visible = true;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);

    }
}
