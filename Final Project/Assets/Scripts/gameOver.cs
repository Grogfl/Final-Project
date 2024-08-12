using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOver : MonoBehaviour
{
public void RetryGame()
    {
        SceneManager.LoadScene("scene1"); 
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
