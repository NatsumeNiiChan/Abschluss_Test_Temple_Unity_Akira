using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetecting : MonoBehaviour
{
    private GameHandler gameScript;

    private void Awake()
    {
        gameScript = FindObjectOfType<GameHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == gameObject.tag)
        {
            gameScript.GuardPoints++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == gameObject.tag)
        {
            gameScript.GuardPoints--;
        }
    }
}
