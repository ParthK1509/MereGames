using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public int leftrightspeed = 4;
    public static float maxSpeed = 10f;

    void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += DisablePlayerMovement;
    }
    
    void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= DisablePlayerMovement;
    }
    void Start(){
        EnablePlayerMovement();
    }
    void Update()
    {
                transform.Translate(Vector3.right * Time.deltaTime * forwardSpeed);
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(Vector3.right * Time.deltaTime * leftrightspeed);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(Vector3.forward * Time.deltaTime * leftrightspeed);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
                transform.Translate(Vector3.back * Time.deltaTime * leftrightspeed);
        }
        
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(Vector3.left * Time.deltaTime * leftrightspeed);
        }
        if(forwardSpeed<maxSpeed){
            forwardSpeed+=Time.deltaTime;
        }
    }
    
    void DisablePlayerMovement(){
forwardSpeed = 0f;
leftrightspeed = 0;
    }
    void EnablePlayerMovement(){
forwardSpeed = 5f;
leftrightspeed = 4; 
    }
}
