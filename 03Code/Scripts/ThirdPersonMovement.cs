using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public GameObject ThePlayer;
    public Animator PlayerAni;

    public float speed = 15f;
    public float gravity = -9.86f;
    public float JumpH = 3f;

    Vector3 velocity;
    bool isGrounded;

    public float turnSmoothTime = 0.01f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
           // PlayerAni.SetBool("isGrounded", true);
           // PlayerAni.SetFloat("velocity.y", 0);

        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PlayerAni.SetBool("isGrounded", false);
            //velocity.y = Mathf.Sqrt(JumpH * -4f * gravity);
            PlayerAni.SetFloat("velocity.y", velocity.y = Mathf.Sqrt(JumpH * -4f * gravity));
        }
        else
        {
            PlayerAni.SetBool("isGrounded", true);
            PlayerAni.SetFloat("velocity.y", -2f);
        }
        velocity.y += gravity * Time.deltaTime;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        controller.Move(velocity * Time.deltaTime);
        //Used to call the run animation on button pressed
        if (Input.GetButton("Vertical"))
        {
            if (PlayerAni)
            {
                PlayerAni.SetBool("Go", true);
                PlayerAni.SetBool("Stop", false);
            }
        }
        //used to call the Idle animation on button let go
        if (Input.GetButtonUp("Vertical"))
        {

            PlayerAni.SetBool("Stop", true);
            PlayerAni.SetBool("Go", false);

        }
        if (Input.GetButton("Horizontal"))
        {
            if (PlayerAni)
            {
                PlayerAni.SetBool("Go", true);
                PlayerAni.SetBool("Stop", false);
            }
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            PlayerAni.SetBool("Stop", true);
            PlayerAni.SetBool("Go", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerAni.SetTrigger("Bow");
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            PlayerAni.SetTrigger("StopBowing");
        }
    }
}
