using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System;
using System.Timers;
using NamespaceScore;


public class Trap : MonoBehaviour
{
    private FirstPersonController firstPersonController;
    public GameObject player;
    public GameObject theTrap;
    public Transform spawnPoint;
    public int TrapCount;
    private Score Score;
    private Vector3 target;

    // Start is called before the first frame update

    void Start()
    {
    Score = GameObject.Find("Score").GetComponent<Score>();
    firstPersonController = player.GetComponent<FirstPersonController>();
    TrapCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        target = firstPersonController.transform.position + firstPersonController.m_Camera.transform.forward;
        if(player.name == "FPSController"+firstPersonController.playerNumber && !Score.isStarting)
        {
            if(Input.GetButtonDown("Player"+firstPersonController.playerNumber+"DropTrap") && TrapCount == 1)
            {
                DropTrap();
            }

        }

    }

    void DropTrap()
    {
        GameObject tp = Instantiate(theTrap, target, theTrap.transform.rotation);
        TrapCount--;
    }

}

