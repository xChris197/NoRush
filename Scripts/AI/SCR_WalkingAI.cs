using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_WalkingAI : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentWaitTime;
    [SerializeField] private float maxWaitTime;
    [SerializeField] private Transform[] moveSpots;

    private int spotNum;

    void Start()
    {
        spotNum = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        transform.LookAt(moveSpots[spotNum]);
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[spotNum].position, speed * Time.deltaTime);

        if(transform.position == moveSpots[spotNum].position)
        {
            if(currentWaitTime <= 0f)
            {
                spotNum = Random.Range(0, moveSpots.Length);
                currentWaitTime = maxWaitTime;
            }
            else
            {
                currentWaitTime -= Time.deltaTime;
            }
        }
    }
}
