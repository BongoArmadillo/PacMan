using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject life_panel;
    
    void Update()
    {
        loseLife();
    }

    void loseLife()
    {
        int numOfLifes = life_panel.transform.childCount;
        if(Input.GetKeyDown(KeyCode.O))
        {
            if(numOfLifes > 0)
            {
                Destroy(life_panel.transform.GetChild(numOfLifes - 1).gameObject);
            }
        }
    }
}
