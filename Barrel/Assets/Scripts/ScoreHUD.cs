// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityStandardAssets.Characters.FirstPerson;
// using UnityEngine.UI;

// public class ScoreHUD : MonoBehaviour
// {
//     Text scoreText;
//     private FirstPersonController player1, player2;
//     // Start is called before the first frame update
//     void Start()
//     {

//         player1 = GameObject.Find("FPSController1").GetComponent<FirstPersonController>();
// 		player2 = GameObject.Find("FPSController2").GetComponent<FirstPersonController>();

//         scoreText = GetComponent<Text>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (gameObject.tag == "player1"){
//            scoreText.text = "Score : " + player1.score;

//         }


//         if (gameObject.tag == "player2"){
//            scoreText.text = "Score : " + player2.score;
//         }
//     }
// }
