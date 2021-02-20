using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System;
using System.Timers;


public class Trap : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    private CharacterController m_CharacterController;
    private FirstPersonController firstPersonController;
    public GameObject player;
    public GameObject theTrap;
    public Transform spawnPoint;
    public int TrapCount;

    // Start is called before the first frame update

    void Start()
    {
    m_CharacterController = player.GetComponent<CharacterController>();
    firstPersonController = player.GetComponent<FirstPersonController>();
    TrapCount = 1;
    }

    // Update is called once per frame
    void Update()
    {

        /*if (timerIsRunning)
        {
            Debug.Log(timerIsRunning);
            if (timeRemaining > 0)
            {

                Debug.Log("ok");
                timeRemaining -= Time.deltaTime;
               
            }
            else
            {
                firstPersonController = GameObject.FindObjectOfType<FirstPersonController>();

                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                Destroy(this.gameObject);
                firstPersonController.m_WalkSpeed = 5;
            }
        }*/

        if(player.name == "FPSController"+firstPersonController.playerNumber)
        {
            if(Input.GetButtonDown("DropTrap"+firstPersonController.playerNumber) && TrapCount == 1)
            {
                DropTrap();
            }

        }

    
        

    }

    void DropTrap()
    {
        GameObject tp = Instantiate(theTrap, spawnPoint.position, theTrap.transform.rotation);
        TrapCount--;
    }

    void OnCollisionEnter(Collision other)
    {

       
       // firstPersonController = GameObject.Find(other.gameObject.name).GetComponent<FirstPersonController>();
       
        //firstPersonController.m_WalkSpeed = 0;

        timerIsRunning = true;
        
        Debug.Log(timerIsRunning);

        
      
    }
}

