using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    
  
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        PlayerMovee.count = 0;
    }

    public void play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        PlayerMovee.count = 0;
    }

    public void menu()
    {
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        Application.Quit();
    }
}
