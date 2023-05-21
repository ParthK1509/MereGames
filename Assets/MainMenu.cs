using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public static event Action OpenedSettings;
    public GameObject SettingMenu;
    public GameObject SpeedMenu;
    public GameObject HealthMenu;
    public TextMeshProUGUI Healthnum;
    public TextMeshProUGUI Speednum;


    public void Settings(){
            //    OpenedSettings?.Invoke();
Debug.Log("clicked");
        if(!SettingMenu.active){
        SettingMenu.SetActive(true);
        }else{
        SettingMenu.SetActive(false);

        }
    }
    public void QuitGame(){
        Application.Quit();
    }
    
    public void StartLevel(){
        SceneManager.LoadScene("SampleScene");
    }
    public void SetSpeed(){
        if(!SpeedMenu.active){
        SpeedMenu.SetActive(true);
        }else{
        SpeedMenu.SetActive(false);

        }
    }
    public void SetHealth(){
        if(!HealthMenu.active){
        HealthMenu.SetActive(true);
        }else{
        HealthMenu.SetActive(false);

        }
    }
    public void IncSpeed(){
        cubeController.maxSpeed++;
    }
    
    public void DecSpeed(){
        cubeController.maxSpeed--;
    }
    
    public void IncHealth(){
        PlayerHealth.maxHealth+=2;
    }
    
    public void DecHealth(){   
        PlayerHealth.maxHealth-=2;
    }
    void Update(){
     Healthnum.text = PlayerHealth.maxHealth.ToString("0");
     Speednum.text = cubeController.maxSpeed.ToString("0");

    }
}
