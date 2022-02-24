using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SwitchingStates : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource coughingAudio;
    
    private bool bSitting = true;
    [SerializeField] private int waitTime;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        if (bSitting)
        {
            waitTime = Random.Range(25, 100);
            StartCoroutine(Wait());
            bSitting = false;
            StartCoroutine(ChangeState());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
    }

    IEnumerator ChangeState()
    {
        anim.SetBool("bIsCoughing", true);
        coughingAudio.Play();
        yield return new WaitForSeconds(6f);
        anim.SetBool("bIsCoughing", false);
        yield return new WaitForSeconds(waitTime);
        bSitting = true;
    }


}
