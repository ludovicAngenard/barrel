using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Text scoreText, ammoText, trapText;
    public FirstPersonController player;
    public Shooting Ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<Text>();
        scoreText = GetComponent<Text>();
        trapText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Score1")
        {
            scoreText.text = "Score : " + player.score;
        }
        if(gameObject.name == "Ammo1")
        {
            ammoText.text = "Ammo : " + Ammo.Ammo+"/4";
        }

        if(gameObject.name == "Trap1")
        {
            trapText.text = "Trap : " + player.GetComponent<Trap>().TrapCount+"/1";
        }
    }

}
