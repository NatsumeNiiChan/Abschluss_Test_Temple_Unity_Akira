using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    private void Awake()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
