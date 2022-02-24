using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CameraLook : MonoBehaviour
{
    public static SCR_CameraLook cameraLook;
    
    [SerializeField] private float lookSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    private float xRotation = 0f;

    private bool canLook = true;
    private bool paused = false;

    void Awake()
    {
        cameraLook = this;
    }

    void Update()
    {
        if(!paused)
        {
            if (canLook)
            {
                float mouseX = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;

                //Clamps the rotation of Y to avoid being able to spin 360 degrees.
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                playerBody.Rotate(Vector3.up * mouseX);
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (canLook)
                {
                    canLook = false;
                    if (SCR_PlayerMovement.playerMovement != null)
                    {
                        SCR_PlayerMovement.playerMovement.ToggleCanMove(false);
                    }
                    if(SCR_PlayerCasting.playerCasting != null)
                    {
                        SCR_PlayerCasting.playerCasting.ToggleCanCast(false);
                    }
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    canLook = true;
                    if (SCR_PlayerMovement.playerMovement != null)
                    {
                        SCR_PlayerMovement.playerMovement.ToggleCanMove(true);
                    }
                    if (SCR_PlayerCasting.playerCasting != null)
                    {
                        SCR_PlayerCasting.playerCasting.ToggleCanCast(true);
                    }
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }               
    }

    public void TogglePausePlayer(bool placeHolder)
    {
        paused = placeHolder; 
        if(placeHolder == false)
        {
            canLook = true;
            if (SCR_PlayerMovement.playerMovement != null)
            {
                SCR_PlayerMovement.playerMovement.ToggleCanMove(true);
            }
            if (SCR_PlayerCasting.playerCasting != null)
            {
                SCR_PlayerCasting.playerCasting.ToggleCanCast(true);
            }
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }
}
