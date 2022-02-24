using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerMovement : MonoBehaviour
{
    public static SCR_PlayerMovement playerMovement;

    private CharacterController controller;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = -19.62f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float jumpForce = 3f;


    private bool canMove = true;
    private bool paused = false;

    private Vector3 velocity;
    bool bIsGrounded;

    void Awake()
    {
        playerMovement = this;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(!paused)
        {
            if(canMove)
            {
                //Checks whether the player is on the ground by casting a sphere and checking if it collides with a layer mask of ground
                bIsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
                if (bIsGrounded && velocity.y < 0f)
                {
                    velocity.y = -2f;
                }

                float movementX = Input.GetAxis("Horizontal");
                float movementZ = Input.GetAxis("Vertical");

                //Uses character controller to input the movement from the Input Manager
                Vector3 move = transform.right * movementX + transform.forward * movementZ;
                controller.Move(move * speed * Time.deltaTime);

                if (Input.GetButtonDown("Jump") && bIsGrounded)
                {
                    velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
                }

                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);
            }
        }      
        
    }

    public void TogglePausePlayer(bool placeHolder)
    {
        paused = placeHolder;
    }

    public void ToggleCanMove(bool placeHolder)
    {
        canMove = placeHolder;
    }

}
