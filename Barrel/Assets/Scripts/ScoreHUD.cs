using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player_controller;
using UnityEngine.UI;

public class ScoreHUD : MonoBehaviour
{
    Text scoreText;
    private PlayerController player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("PlayerParent").GetComponent<PlayerController>();
		player2 = GameObject.Find("PlayerParent2").GetComponent<PlayerController>();
        scoreText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "player1"){
           scoreText.text = "Score : " + player1.getScore();
        }
        if (gameObject.tag == "player2"){
           scoreText.text = "Score : " + player2.getScore();
        }
    }
}
