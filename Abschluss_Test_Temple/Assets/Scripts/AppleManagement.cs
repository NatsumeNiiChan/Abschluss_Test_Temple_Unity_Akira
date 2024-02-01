using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManagement : MonoBehaviour
{
    private Vector3 mousePosition;
    private Color col;
    private bool isDragged;
    private bool isFinished;
    private GameHandler gameScript;
    [SerializeField] private float rotation;
    [SerializeField] private float dist;
    
    [SerializeField] private Transform appleTrans;

    private void Awake()
    {
        rotation = GetComponent<Transform>().rotation.z;
        gameScript = FindObjectOfType<GameHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && isDragged == true)
        {
            gameObject.transform.Rotate(0, 0, 45);
            rotation = GetComponent<Transform>().rotation.z;
        }

        CalculateDistance();

        if (dist <= 0.1f && rotation <= 0.1 && isFinished == false)
        {
            isFinished = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        col = GetComponent<MeshRenderer>().material.color;
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        isDragged = true;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }

    private void OnMouseUp()
    {
        GetComponent<MeshRenderer>().material.color = col;
        isDragged = false;
        
        if (isFinished == true)
        {
            gameObject.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
            gameScript.ApplePoints++;
        }
    }

    private void CalculateDistance()
    {
        if (appleTrans)
        {
            dist = Vector3.Distance(appleTrans.transform.position, gameObject.transform.position);
        }
    }
}
