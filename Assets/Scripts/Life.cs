using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public GameObject life_panel;
    Vector3 originalPositionPlayer;
    Vector3 originalPositionGhost1;
    Vector3 originalPositionGhost2;
    Vector3 originalPositionGhost3;
    CharacterController cc;

    public Transform ghost1;
    public Transform ghost2;
    public Transform ghost3;

    private void Start() {
        cc = GetComponent(typeof(CharacterController)) as CharacterController;
        originalPositionPlayer = gameObject.transform.position;
        originalPositionGhost1 = ghost1.transform.position;
        originalPositionGhost2 = ghost2.transform.position;
        originalPositionGhost3 = ghost3.transform.position;
    }


    // async void Timer(){
    //     float t = 5f;

    //     while(t>0){

    //         t-=Time.deltaTime;
    //         await Task.Yield();
    //     }
    // }


    

    void Update()
    {
       cc.enabled = true;
       
    }

 public void OnTriggerEnter(Collider other) {
     int numOfLifes = life_panel.transform.childCount;
     if(other.gameObject.CompareTag("Ghost") && numOfLifes > 0)
     {            
            Destroy(life_panel.transform.GetChild(numOfLifes - 1).gameObject);
            gameObject.transform.position = originalPositionPlayer;
            ghost1.transform.position = originalPositionGhost1;
            ghost2.transform.position = originalPositionGhost2;
            ghost3.transform.position = originalPositionGhost3;
            GameObject.FindGameObjectWithTag("SpeedBoost").SetActive(true);
            cc.enabled = false;           
     }

 }


}
