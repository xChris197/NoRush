using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Talker : MonoBehaviour
{
    [SerializeField] private AudioSource[] dialogue;
    [SerializeField] private int invokeTime;
    private bool bTalkReady = true;

    void Update()
    {
        if (bTalkReady)
        {
            invokeTime = Random.Range(15, 25);
            bTalkReady = false;
            Invoke("ChooseDialogue", invokeTime);
        }
    }

    void ChooseDialogue()
    {
        int choice = Random.Range(0, dialogue.Length);
        dialogue[choice].Play();
        bTalkReady = true;
    }
}
