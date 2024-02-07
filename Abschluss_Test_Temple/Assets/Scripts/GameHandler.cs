using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public int ApplePoints;
    public int LightPoints;
    public int GuardPoints;
    private GameObject appleDoor;
    private GameObject lightDoor;
    private GameObject guardDoor;
    private GameObject winScreen;
    private bool isAppleFinished;
    private bool isLightFinished;
    private bool hintActive;

    public List<GameObject> LightObjects;

    [SerializeField] private GameObject camOne;
    [SerializeField] private GameObject camTwo;
    [SerializeField] private GameObject camThree;
    [SerializeField] private GameObject appleCam;
    [SerializeField] private GameObject lightCam;

    [SerializeField] private GameObject uiOne;
    [SerializeField] private GameObject uiTwo;
    [SerializeField] private GameObject uiThree;
    [SerializeField] private GameObject uiApple;
    [SerializeField] private GameObject uiLight;
    [SerializeField] private GameObject uiHintLight;

    private void Awake()
    {
        appleDoor = GameObject.Find("DoorOne");
        lightDoor = GameObject.Find("DoorTwo");
        guardDoor = GameObject.Find("DoorThree");
        winScreen = GameObject.Find("WinScreen");

        winScreen.SetActive(false);
    }

    private void Update()
    {
        if (ApplePoints >= 4)
        {
            appleDoor.SetActive(false);
            isAppleFinished = true;
        }

        if (LightPoints >= 4)
        {
            lightDoor.SetActive(false);
            isLightFinished = true;
        }

        if (GuardPoints >= 4)
        {
            guardDoor.SetActive(false);
            winScreen.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && hintActive == true)
        {
            uiHintLight.SetActive(false);
            hintActive = false;
        }
    }

    public void GoToRoomTwo()
    {
        if(isAppleFinished == true)
        {
            camOne.SetActive(false);
            camTwo.SetActive(true);
            uiOne.SetActive(false);
            uiTwo.SetActive(true);
        }
    }

    public void GoToRoomThree()
    {
        if(isLightFinished == true)
        {
            camTwo.SetActive(false);
            camThree.SetActive(true);
            uiTwo.SetActive(false);
            uiThree.SetActive(true);
        }
    }

    public void StartApple()
    {
        camOne.SetActive(false);
        appleCam.SetActive(true);
        uiOne.SetActive(false);
        uiApple.SetActive(true);
    }

    public void FinishApple()
    {
        camOne.SetActive(true);
        appleCam.SetActive(false);
        uiOne.SetActive(true);
        uiApple.SetActive(false);
    }

    public void StartLight()
    {
        camTwo.SetActive(false);
        lightCam.SetActive(true);
        uiTwo.SetActive(false);
        uiLight.SetActive(true);
    }

    public void FinishLight()
    {
        camTwo.SetActive(true);
        lightCam.SetActive(false);
        uiTwo.SetActive(true);
        uiLight.SetActive(false);
    }

    public void OpenHint()
    {
        uiHintLight.SetActive(true);
        hintActive = true;
    }
}
