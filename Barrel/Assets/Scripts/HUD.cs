using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Text scoreText, ammoText, trapText;
    private FirstPersonController player1, player2;
    private Shooting Ammo1,Ammo2;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("FPSController1").GetComponent<FirstPersonController>();
		player2 = GameObject.Find("FPSController2").GetComponent<FirstPersonController>();

        Ammo1 = GameObject.Find("colt1").GetComponent<Shooting>();
        Ammo2 = GameObject.Find("colt2").GetComponent<Shooting>();

        ammoText = GetComponent<Text>();
        scoreText = GetComponent<Text>();
        trapText = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "player1")
        {
            if(gameObject.name == "Score1")
            {
                scoreText.text = "Score : " + player1.score;
            } 
            if(gameObject.name == "Ammo1")
            {
                ammoText.text = "Ammo : " + Ammo1.Ammo+"/4";
            }

            if(gameObject.name == "Trap1")
            {
                trapText.text = "Trap : " + player1.GetComponent<Trap>().TrapCount+"/1";
            }

        }
       

        if (gameObject.tag == "player2")
        {

            if(gameObject.name == "Score2")
            {
                scoreText.text = "Score : " + player2.score;
            } 

            if(gameObject.name == "Ammo2")
            {
                ammoText.text = "Ammo : " + Ammo2.Ammo+"/4";
            }

            if(gameObject.name == "Trap2")
            {
                trapText.text = "Trap : " + player2.GetComponent<Trap>().TrapCount+"/1";
            }
        }
    }
    
}
