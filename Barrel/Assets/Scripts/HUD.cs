using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player_controller;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Text scoreText, ammoText, trapText;
    public PlayerController player;
    public Shooting Ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<Text>();
        scoreText = GetComponent<Text>();
        trapText = GetComponent<Text>();
        Debug.Log( "Score : " + player.getScore() + Ammo.Ammo+"/4");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Score")
        {
            scoreText.text = "Score : " + player.getScore();
        }
        if(gameObject.name == "Ammo")
        {
            ammoText.text = "Ammo : " + Ammo.Ammo+"/4";
        }

        if(gameObject.name == "Trap")
        {
            trapText.text = "Trap : " + player.GetComponent<Trap>().TrapCount+"/1";
        }
    }

}
