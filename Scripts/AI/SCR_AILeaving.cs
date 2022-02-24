using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_AILeaving : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField] private GameObject[] childObjs;

    private bool bIsReadyToWalk = false;
    private bool bCanDespawn = true;
    private float distanceToEndPoint;

    [SerializeField] private Transform finalWalkPoint;
    private int waitTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        waitTime = Random.Range(30, 60);
        StartCoroutine(Wait());
    }

    void Update()
    {
        distanceToEndPoint = Vector3.Distance(transform.position, finalWalkPoint.position);

        if (bIsReadyToWalk)
        {
            StartCoroutine(WalkToEndPoint());
        }

        if (distanceToEndPoint <= 2f && bCanDespawn)
        {
            bCanDespawn = false;
            DisableComponents();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        bIsReadyToWalk = true;
    }

    IEnumerator WalkToEndPoint()
    {
        bIsReadyToWalk = false;
        yield return new WaitForSeconds(1f);
        anim.SetBool("bIsLeaving", true);
        agent.SetDestination(finalWalkPoint.transform.position);
    }

    //Disables the child gameobjects to give the illusion of despawning
    void DisableComponents()
    {
        for (int i = 0; i < childObjs.Length; i++)
        {
            childObjs[i].SetActive(false);
        }
    }
}