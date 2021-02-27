using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int score1, score2;
    Text score;
    public static int round;


    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        score.text = "Score J1: " + score1 + "Score J2: " + score2 + " Round n°" + round;
        Win();
    }


    // void OnDisable()
    // {
    // PlayerPrefs.SetInt("score", score1);
    // PlayerPrefs.SetInt("score", score2);
    // PlayerPrefs.SetInt("round", round);
    // }

    // void OnEnable()
    // {

    // score.text = "Score J1: " + score1 + " Score J2:" + score2 + "Round n°" + round;
    // score1  =  PlayerPrefs.GetInt("score");
    // score2  =  PlayerPrefs.GetInt("score");
    // round  =  PlayerPrefs.GetInt("round");
    
    // }

    void Win()
    {
       
            if(score1==2)
            {
                Debug.Log("Joueur 1 Gagnant !");
            }
            if(score2==2)
            {
                Debug.Log("Joueur 2 Gagnant !");
            }
        
    }
}
