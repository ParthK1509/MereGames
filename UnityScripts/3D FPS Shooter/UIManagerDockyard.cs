using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManagerDockyard : MonoBehaviour
{
    public GameObject MenuButton;
    public void QuitGame(){
        Application.Quit();
    }
    public void StartLevel(){
        SceneManager.LoadScene("Scene1");
    }

}
