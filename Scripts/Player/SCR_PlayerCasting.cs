using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerCasting : MonoBehaviour
{
    public static SCR_PlayerCasting playerCasting;

    public static float distanceFromTarget;
    public static GameObject hitTarget;

    private bool canCast = true;
    private bool paused = false;

    void Awake()
    {
        playerCasting = this;
    }

    void Update()
    {
        if(!paused)
        {
            if(canCast)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    distanceFromTarget = hit.distance;
                    hitTarget = hit.transform.gameObject;
                }
            }
        }        
    }

    public void TogglePausePlayer(bool placeHolder)
    {
        paused = placeHolder;
        distanceFromTarget = 1000;
    }

    public void ToggleCanCast(bool placeHolder)
    {
        canCast = placeHolder;
        distanceFromTarget = 1000;
    }
}
