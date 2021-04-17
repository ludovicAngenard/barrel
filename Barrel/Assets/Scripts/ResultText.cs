using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using NamespaceGameManager;



public class ResultText : MonoBehaviour
{
    private Text text;
    private GameManager gameManager;
    private FirstPersonController fpsController;
    public string result;
    void Start()
    {
        text = GetComponent<Text>();
        gameManager = GameObject.Find("GameManagerTEST").GetComponent<GameManager>();
        gameManager.isFinish = true;
        FindPlayer();

        Debug.Log("winner"+gameManager.winner);
        Debug.Log("looser"+gameManager.looser);
    }

    void Update()
    {
        text.text = "player" + fpsController.playerNumber + ", vous avez " + result + "!";
    }

    void FindPlayer(){
        if (result == "gagné"){
            fpsController = gameManager.GetWinner().GetComponent<FirstPersonController>();
        } else if (result == "perdu"){
            fpsController = gameManager.GetLooser().GetComponent<FirstPersonController>();
        }
    }

}
