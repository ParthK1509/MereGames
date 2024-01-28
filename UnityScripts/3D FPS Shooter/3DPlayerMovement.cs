using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    float VerticalSpeed = 0;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
         Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (baseSpeed) * Time.deltaTime);
    }
}
