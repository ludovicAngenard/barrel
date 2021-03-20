using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NamespaceScore;


namespace namespaceFinish{
    public class Finish : MonoBehaviour
    {
        Text winnerText, looserText;
        private FirstPersonController winner;
        private FirstPersonController looser;
        void Start()
        {
            winner.m_Camera.enabled = false;
            looser.m_Camera.enabled = false;
            winnerText.text = "Bravo " + winner.name + " Vous avez remporté ce duel !";
            looserText.text = looserText.name + ", vous avez perdu !";
        }

        // Update is called once per frame
        void Update()
        {
        }
        void SetWinner(FirstPersonController player){
            winner = player;
        }
        void SetLooser(FirstPersonController player){
            looser = player;
        }
    }
}