using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private bool lightOne;
    [SerializeField] private bool lightTwo;
    [SerializeField] private bool lightThree;
    [SerializeField] private bool lightFour;
    [SerializeField] private Material lightMaterial;
    [SerializeField] private Material normalMaterial;

    private AudioSource rightSound;
    private GameHandler gameScript;
    private Vector3 mousePosition;

    private void Awake()
    {
        gameScript = FindObjectOfType<GameHandler>();
        rightSound = FindObjectOfType<AudioSource>();

        gameScript.LightObjects.Add(gameObject);
    }


    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();

        if (lightOne == true && gameScript.LightPoints == 0)
        {
            gameScript.LightPoints++;
            GetComponent<Renderer>().material = lightMaterial;
            rightSound.Play();
        }

        else if (lightTwo == true && gameScript.LightPoints == 1)
        {
            gameScript.LightPoints++;
            GetComponent<Renderer>().material = lightMaterial;
            rightSound.Play();
        }

        else if (lightThree == true && gameScript.LightPoints == 2)
        {
            gameScript.LightPoints++;
            GetComponent<Renderer>().material = lightMaterial;
            rightSound.Play();
        }

        else if (lightFour == true && gameScript.LightPoints == 3)
        {
            gameScript.LightPoints++;
            GetComponent<Renderer>().material = lightMaterial;
            rightSound.Play();
        }

        else
        {
            foreach (GameObject light in gameScript.LightObjects)
            {
                light.GetComponent<Renderer>().material = normalMaterial;
            }
            
            gameScript.LightPoints = 0;
        }
    }
}
