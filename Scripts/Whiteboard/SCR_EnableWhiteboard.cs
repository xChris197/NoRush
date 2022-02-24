using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnableWhiteboard : MonoBehaviour
{
    private GameObject player;
    private SCR_Whiteboard whiteboardScript;
    private GameObject brush;
    private float distance;
    private GameObject hitTarget;
    [SerializeField] private float interactionDistance = 1f;

    [SerializeField] private Camera playerCam;
    [SerializeField] private GameObject whiteboard;
    [SerializeField] private Camera whiteboardCam;
    [SerializeField] private GameObject whiteboardExitButton;
    [SerializeField] private GameObject redBrushButton;
    [SerializeField] private GameObject blueBrushButton;
    [SerializeField] private GameObject greenBrushButton;
    [SerializeField] private GameObject yellowBrushButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private Material red;

    private SCR_CameraLook camLook;
    private SCR_PlayerMovement playerMovement;
    private GameObject[] brushes;
    private Renderer rend;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camLook = player.GetComponentInChildren<SCR_CameraLook>();
        playerMovement = player.GetComponent<SCR_PlayerMovement>();
        whiteboardScript = whiteboard.GetComponent<SCR_Whiteboard>();
        brush = whiteboardScript.brush;
        rend = brush.GetComponent<Renderer>();
    }

    void Update()
    {
        distance = SCR_PlayerCasting.distanceFromTarget;
        hitTarget = SCR_PlayerCasting.hitTarget;
        brushes = GameObject.FindGameObjectsWithTag("Brush");
    }
    void OnMouseOver()
    {
        if (distance <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.E) && hitTarget.CompareTag("Whiteboard"))
            {
                DisablePlayer();
                EnableWhiteboard();
            }
        }
    }

    void DisablePlayer()
    {
        playerCam.enabled = false;
        camLook.enabled = false;
        playerMovement.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    void EnableWhiteboard()
    {
        pauseButton.SetActive(false);
        whiteboardCam.enabled = true;
        whiteboard.SetActive(true);
        whiteboardExitButton.SetActive(true);
        redBrushButton.SetActive(true);
        blueBrushButton.SetActive(true);
        greenBrushButton.SetActive(true);
        yellowBrushButton.SetActive(true);
    }

    public void DisableWhiteboard()
    {
        for(int i = 0; i < brushes.Length; i++)
        {
            Destroy(brushes[i]);
        }
        pauseButton.SetActive(true);
        rend.material = red;
        whiteboardCam.enabled = false;
        whiteboard.SetActive(false);
        whiteboardExitButton.SetActive(false);
        redBrushButton.SetActive(false);
        blueBrushButton.SetActive(false);
        greenBrushButton.SetActive(false);
        yellowBrushButton.SetActive(false);
        playerCam.enabled = true;
        camLook.enabled = true;
        playerMovement.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
