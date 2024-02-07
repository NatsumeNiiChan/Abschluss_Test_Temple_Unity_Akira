using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSpinning : MonoBehaviour
{
    private float y;
    private float rotationSpeed = 1;
    private bool isPressed;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (isPressed == true)
        {
            transform.Rotate(0, rotationSpeed, 0);

            y++;
        }
    }

    private void OnMouseDrag()
    {
        float CubeXRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float CubeYRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(Vector3.down, CubeXRotation);
        transform.Rotate(Vector3.right, CubeYRotation);
    }

    public void ButtonOnHold()
    {
        isPressed = true;
    }

    public void ButtonOffHold()
    {
        isPressed = false;
    }

    public void TurnLeft()
    {
        rotationSpeed = 1;
    }

    public void TurnRight()
    {
        rotationSpeed = -1;
    }
}
