using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehaviour : MonoBehaviour
{

    public GameObject Level_complete;
   
      void Start() {
       Level_complete.SetActive(false);
}

    
    void Update()
    {
       Winning(); 
    }

     void Winning()
    {
        if(PlayerMovee.count == 5)
        {
        Level_complete.SetActive(true);
        Invoke("stopGame", 1.1f);
        }
    }

    void stopGame()
    {
        Time.timeScale = 0f;
    }
}
