using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public int ApplePoints;
    public AudioClip correctSound;
    private GameObject appleDoor;
    private bool isAppleFinished;

    [SerializeField] private GameObject camOne;
    [SerializeField] private GameObject camTwo;
    [SerializeField] private GameObject camThree;
    [SerializeField] private GameObject appleCam;

    [SerializeField] private GameObject uiOne;
    [SerializeField] private GameObject uiTwo;
    [SerializeField] private GameObject uiThree;
    [SerializeField] private GameObject uiApple;

    private void Awake()
    {
        appleDoor = GameObject.Find("DoorOne");
    }

    private void Update()
    {
        if (ApplePoints >= 4)
        {
            appleDoor.SetActive(false);
            isAppleFinished = true;
        }
    }

    public void GoToRoomTwo()
    {
        if(isAppleFinished == true)
        {
            camOne.SetActive(false);
            camTwo.SetActive(true);
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
}
