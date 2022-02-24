using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;

public class SCR_Whiteboard : MonoBehaviour
{
    public GameObject brush;
    [SerializeField] private Camera currentCam;
    [SerializeField] private float secondsToWait = 10f;
    [SerializeField] private float brushSize = 0.1f;

    [SerializeField] private Material red;
    [SerializeField] private Material blue;
    [SerializeField] private Material green;
    [SerializeField] private Material yellow;
    private Renderer rend;

    void Start()
    {
        rend = brush.GetComponent<Renderer>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartCoroutine(Draw());
        }
    }

    IEnumerator Draw()
    {
        var ray = currentCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject brushGO = Instantiate(brush, hit.point, Quaternion.Euler(90, 0, -180));
            brushGO.transform.localScale = Vector3.one * brushSize;
            yield return new WaitForSeconds(secondsToWait);
            Destroy(brushGO);
        }
    }

    public void RedBrush()
    {
        rend.material = red;
    }

    public void BlueBrush()
    {
        rend.material = blue;
    }

    public void GreenBrush()
    {
        rend.material = green;
    }

    public void YellowBrush()
    {
        rend.material = yellow;
    }
}