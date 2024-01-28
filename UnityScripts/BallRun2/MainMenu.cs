using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    public static event Action OpenedSettings;
    public GameObject SettingMenu;
    public GameObject SpeedMenu;
    public GameObject HealthMenu;
    public TextMeshProUGUI Healthnum;
    public TextMeshProUGUI Speednum;
    [SerializeField] AudioClip ClickFX;
    [SerializeField] AudioClip StartFX;


    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Hello!");
        SceneManager.LoadScene("SampleScene");

    }
    public void Settings()
    {
        //    OpenedSettings?.Invoke();
        Debug.Log("clicked");
        GetComponent<AudioSource>().PlayOneShot(ClickFX);
        if (!SettingMenu.active)
        {
            SettingMenu.SetActive(true);
        }
        else
        {
            SettingMenu.SetActive(false);

        }
    }
    public void QuitGame()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickFX);
        Application.Quit();
    }

    public void StartLevel()
    {
        GetComponent<AudioSource>().PlayOneShot(StartFX);
        StartCoroutine(WaitForFunction());
        // SceneManager.LoadScene("SampleScene");
    }

    public void SetSpeed()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickFX);
        if (!SpeedMenu.active)
        {
            SpeedMenu.SetActive(true);
        }
        else
        {
            SpeedMenu.SetActive(false);

        }
    }
    public void SetHealth()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickFX);
        if (!HealthMenu.active)
        {
            HealthMenu.SetActive(true);
        }
        else
        {
            HealthMenu.SetActive(false);

        }
    }
    public void IncSpeed()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickFX);
        cubeController.maxSpeed++;
    }

    public void DecSpeed()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickFX);
        cubeController.maxSpeed--;
    }

    public void IncHealth()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickFX);
        PlayerHealth.maxHealth += 1;
    }

    public void DecHealth()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickFX);
        PlayerHealth.maxHealth -= 1;
    }
    void Update()
    {
        Healthnum.text = PlayerHealth.maxHealth.ToString("0");
        Speednum.text = cubeController.maxSpeed.ToString("0");

    }
}
