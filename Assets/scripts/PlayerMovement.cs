using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float acceleration;
    public float airControl;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    public Vector3 velocity;
    private bool isGrounded;

    private float x;
    private float z;
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
        if (isGrounded)
        {
            if (x < -0.1 || x > 0.1)
            {
                velocity.x = Mathf.Lerp(velocity.x, x, Time.deltaTime * acceleration);
            }
            else
            {
                velocity.x = Mathf.Lerp(velocity.x, 0, Time.deltaTime * acceleration);
            }
            
            if (z < -0.1 || z > 0.1)
            {
                velocity.z = Mathf.Lerp(velocity.z, z, Time.deltaTime * acceleration);
            }
            else
            {
                velocity.z = Mathf.Lerp(velocity.z, 0, Time.deltaTime * acceleration);
            }
        }
        else
        {
            if (x < -0.1 || x > 0.1)
            {
                velocity.x = Mathf.Lerp(velocity.x, x, Time.deltaTime * airControl);
            }
            
            if (z < -0.1 || z > 0.1)
            {
                velocity.z = Mathf.Lerp(velocity.z, z, Time.deltaTime * airControl);
            }
        }
        
        Vector3 move = transform.right * velocity.x + transform.forward * velocity.z;
        
        controller.Move(move * speed * Time.deltaTime);
        
        
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
