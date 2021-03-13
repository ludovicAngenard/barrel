using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System;
using System.Timers;


public class Trap : MonoBehaviour
{
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

        if(player.name == "FPSController"+firstPersonController.playerNumber)
        {
            if(Input.GetButtonDown("Player"+firstPersonController.playerNumber+"DropTrap") && TrapCount == 1)
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

}

