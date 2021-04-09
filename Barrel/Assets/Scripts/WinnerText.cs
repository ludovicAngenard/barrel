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
        void Start()
        {
            isFinish = true;
            winnerText = GetComponent<Text>();
            winnerText.text = "oui";
            winnerText.text = "player" + winner.GetComponent<FirstPersonController>().playerNumber + ", vous avez Gagné !";
        }
        void ChangeText(){
            winnerText.text = winnerText.name + ", vous avez Ggané !";
        }
    }
}