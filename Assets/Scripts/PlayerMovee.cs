using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovee : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public GameObject pauseGameMenu;
    public GameObject Level_completed;

    [Header("Controlls")]
    public KeyCode pause = KeyCode.Escape;


    
    public float speed = 6;
    
    public static int count = 0;
    private float turnSmoothVelocity;
    private float turnSmoothTime = 0.1f;



    
    void Update()
    {   
        
        menuPause();
       
       //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            Debug.LogError(count);
        }

        if(other.gameObject.CompareTag("SpeedBoost"))
        {
            other.gameObject.SetActive(false);
            speed = 10;
            Invoke("speedboostend", 5f);
            
        }

    }

    void speedboostend()
    {
        speed = 6;
    }

   

    void menuPause()
    {
        if(Input.GetKeyDown(pause) && pauseGameMenu.activeSelf == false && Level_completed.activeSelf == false)
        {
            pauseGameMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(Input.GetKeyDown(pause) && pauseGameMenu.activeSelf == true && Level_completed.activeSelf == false)
        {           
            pauseGameMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
