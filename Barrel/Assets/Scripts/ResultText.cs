// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityStandardAssets.Characters.FirstPerson;
// using UnityEngine.UI;
// using NamespaceGameManager;



// public class ResultText : MonoBehaviour
// {
//     private Text text;
//     private GameManager gameManager;
//     public FirstPersonController fpsController;
//     public string result;
//     void Start()
//     {
//         text = GetComponent<Text>();
//         gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
//         gameManager.isFinish = true;
//         FindPlayer();

//     }

//     void Update()
//     {

//         text.text = "player" + fpsController.playerNumber + ", vous avez " + result + "!";
//     }

//     void FindPlayer(){
//         if (result == "gagné"){
//             fpsController = gameManager.GetWinner().GetComponent<FirstPersonController>();
//         } else if (result == "perdu"){
//             fpsController = gameManager.GetLooser().GetComponent<FirstPersonController>();
//         }
//     }

// }
