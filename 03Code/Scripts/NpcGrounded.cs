using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGrounded : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -9.81f;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask GroundMask;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -5f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
