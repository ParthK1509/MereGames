using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    
    void Update(){
        
    }
    public void TakeDamage(float amount){
        health -= amount;
        if(health<=0f){
            die();
        }
    }
    void die(){
        Destroy(gameObject);
    }
}
