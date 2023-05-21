using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action OnPlayerDeath;
    public static float health,maxHealth=5f;
public TextMeshProUGUI HealthText;

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float amount){
            health -= amount;
            print("Health Lost");
            if(health<= 0){
                health = 0;
                OnPlayerDeath?.Invoke();
            }
    }
    
    void Update(){  
     HealthText.text = "Health: " + health;
     if(gameObject.transform.position.y<-10){
                OnPlayerDeath?.Invoke();

     }   
    }
}
