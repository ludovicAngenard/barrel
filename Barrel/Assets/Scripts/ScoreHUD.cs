using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player;
using UnityEngine.UI;

public class ScoreHUD : MonoBehaviour
{
    Text scoreText;
    private Player player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("PlayerParent").GetComponent<Player>();
		player2 = GameObject.Find("PlayerParent2").GetComponent<Player>();
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
