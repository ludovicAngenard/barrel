using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player_controller;
using System;
using System.Timers;
using NamespaceGameManager;


public class Trap : MonoBehaviour
{
    private PlayerController player;
    public GameObject playerObject;
    public GameObject theTrap;
    public Transform spawnPoint;
    public int TrapCount;
    private GameManager GameManager;
    private Vector3 target;

    // Start is called before the first frame update

    void Start()
    {
    GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    player = playerObject.GetComponent<PlayerController>();
    TrapCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position + playerObject.GetComponent<Camera>().transform.forward;
        if(playerObject.name == "FPSController"+player.getPlayerNumber() && !GameManager.isStarting)
        {
            if(Input.GetButtonDown("Player"+player.getPlayerNumber()+"DropTrap") && TrapCount == 1)
            {
                DropTrap();
            }

        }

    }

    void DropTrap()
    {
        GameObject tp = Instantiate(theTrap, spawnPoint.transform.position, theTrap.transform.rotation);
        TrapCount--;
    }

}

