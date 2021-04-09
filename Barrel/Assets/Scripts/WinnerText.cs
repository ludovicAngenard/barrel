using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using NamespaceGameManager;


namespace namespaceWinnerText{
    public class WinnerText : GameManager
    {
        private Text winnerText;
        public GameManager gameManager;
        void Start()
        {
            isFinish = true;
            winnerText = GetComponent<Text>();
            winnerText.text = "oui";
            gameManager = GameObject.Find("Score").GetComponent<GameManager>();
            winnerText.text = "player" + gameManager.GetWinner().GetComponent<FirstPersonController>().playerNumber + ", vous avez Gagné !";
        }
        void ChangeText(){
            winnerText.text = winnerText.name + ", vous avez Ggané !";
        }
    }
}