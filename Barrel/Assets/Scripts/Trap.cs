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
    private FirstPersonController fpc;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                fpc = GameObject.FindObjectOfType<FirstPersonController>();

                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                Destroy(this.gameObject);
                fpc.m_WalkSpeed = 5;
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        fpc = GameObject.FindObjectOfType<FirstPersonController>();
       
        fpc.m_WalkSpeed = 0;

        timerIsRunning = true;
      
        
    }
}