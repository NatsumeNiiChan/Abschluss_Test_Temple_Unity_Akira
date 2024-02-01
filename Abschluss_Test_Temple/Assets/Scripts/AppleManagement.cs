using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManagement : MonoBehaviour
{
    private Vector3 mousePosition;
    private Color col;
    private bool isDragged;
    private float rotation;
    [SerializeField] private float dist;
    
    [SerializeField] private Transform appleTrans;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && isDragged == true)
        {
            gameObject.transform.Rotate(0, 0, 45);
            rotation = GetComponent<Transform>().rotation.z;
        }

        CalculateDistance();

        if (dist <= 0.1f && rotation <= 1)
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            gameObject.GetComponent<AppleManagement>().enabled = false;
            Destroy(gameObject.GetComponent<AppleManagement>());
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
    }

    private void CalculateDistance()
    {
        if (appleTrans)
        {
            dist = Vector3.Distance(appleTrans.transform.position, gameObject.transform.position);
        }
    }
}
