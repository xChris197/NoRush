using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_RandomiseAppearance : MonoBehaviour
{
    [SerializeField] private Renderer[] materialRends;
    [SerializeField] private Material[] materialColours;

    void Start()
    {
        RandomiseLook();
    }

    void RandomiseLook()
    {
        for (int i = 0; i < materialRends.Length; i++)
        {
            int randomNum = Random.Range(0, materialColours.Length);
            materialRends[i].material = materialColours[randomNum];
        }
    }
}
