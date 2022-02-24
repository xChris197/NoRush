using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_AIWalking : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField] private GameObject[] childObjs;
    [SerializeField] private Renderer[] materialRends;
    [SerializeField] private Material[] materialColours;

    private bool bIsReadyToWalk = true;
    private bool bCanWalkBack = false;
    private bool bCanDespawn = true;
    private float distanceToEndPoint;
    private float distanceToStartPoint;

    [SerializeField] private Transform firstWalkPoint;
    [SerializeField] private Transform finalWalkPoint;
    private int waitTime;
    private int despawnWaitTime;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        waitTime = Random.Range(1, 10);
        despawnWaitTime = Random.Range(1, 7);
    }

    void Update()
    {
        distanceToEndPoint = Vector3.Distance(transform.position, finalWalkPoint.position);
        distanceToStartPoint = Vector3.Distance(transform.position, firstWalkPoint.position);

        if (bIsReadyToWalk)
        {
            StartCoroutine(WalkToEndPoint());
        }

        if (bCanWalkBack)
        {
            WalkBackToStart();
        }

        if(distanceToEndPoint <= 1f && bCanDespawn)
        {
            bCanDespawn = false;
            StartCoroutine(Despawn());
        }

        if(distanceToStartPoint <= 1f && !bIsReadyToWalk)
        {
            bIsReadyToWalk = true;
            bCanDespawn = true;
        }
    }

    IEnumerator WalkToEndPoint()
    {
        bIsReadyToWalk = false;
        anim.SetBool("bIsWalking", false);
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("bIsWalking", true);
        agent.SetDestination(finalWalkPoint.transform.position);
    }

    void WalkBackToStart()
    {
        bCanWalkBack = false;
        agent.SetDestination(firstWalkPoint.transform.position);
    }

    IEnumerator Despawn()
    {
        DisableComponents();
        yield return new WaitForSeconds(despawnWaitTime);
        RandomiseLook();
        EnableComponents();
        bCanWalkBack = true;
    }

    //Enables the child gameobjects to give the illusion of respawning
    void EnableComponents()
    {
        for(int i = 0; i < childObjs.Length; i++)
        {
            childObjs[i].SetActive(true);
        }
    }

    //Disables the child gameobjects to give the illusion of despawning
    void DisableComponents()
    {
        for (int i = 0; i < childObjs.Length; i++)
        {
            childObjs[i].SetActive(false);
        }
    }

    void RandomiseLook()
    {
        for(int i = 0; i < materialRends.Length; i++)
        {
            int randomNum = Random.Range(0, materialColours.Length);
            materialRends[i].material = materialColours[randomNum];
        }
    }
}
