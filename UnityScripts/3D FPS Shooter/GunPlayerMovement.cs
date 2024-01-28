using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GunPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraHolder;

    public Animator animator;
    public float baseSpeed = 12f;
    public float mouseSensitivity = 3f;
    public float upLimit = -50;
    public float downLimit = 50;

    float VerticalSpeed = 0;
    public float gravity = -100f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;
    Vector3 velocity;
    public Vector3 currentRotation;
    
    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal"))+Mathf.Abs(Input.GetAxis("Vertical")));
        
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            Jump();            
        }
        // if (Input.GetButtonDown("Fire1") )
        // {
        //     animator.SetBool("isShooting",true);            
        // }
       
    }
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Jump(){
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    public void Rotate(){
        
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");
        
        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verticalRotation*mouseSensitivity,0,0);

        currentRotation = cameraHolder.localEulerAngles;//defining
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);//rotation relative to parent
    }

    public void Move(){
         float x = Input.GetAxis("Horizontal");
         float z = Input.GetAxis("Vertical");
         Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (baseSpeed) * Time.deltaTime);

        // Command keySpace = new Jump();
        
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
}
