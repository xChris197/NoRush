using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MusicPlayer : MonoBehaviour
{
    private float distance;
    [SerializeField] private float pickupDistance = 1f;
    private SCR_PlayerMovement movement;
    private SCR_CameraLook look;
    private GameObject hitTarget;

    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCam;
    [SerializeField] private GameObject musicUI;
    [SerializeField] private GameObject pauseButton;

    void Start()
    {
        movement = player.GetComponent<SCR_PlayerMovement>();
        look = playerCam.GetComponent<SCR_CameraLook>();
    }

    void Update()
    {
        distance = SCR_PlayerCasting.distanceFromTarget;
        hitTarget = SCR_PlayerCasting.hitTarget;
    }
    void OnMouseOver()
    {
        if (distance <= pickupDistance)
        {
            if (Input.GetKeyDown(KeyCode.E) && hitTarget.CompareTag("Music"))
            {
                DisablePlayer();
                musicUI.SetActive(true);
            }
        }
    }

    void DisablePlayer()
    {
        pauseButton.SetActive(false);
        movement.enabled = false;
        look.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
