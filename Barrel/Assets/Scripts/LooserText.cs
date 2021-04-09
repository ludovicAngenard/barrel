using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using NamespaceGameManager;


namespace namespaceLooserText{
    public class LooserText : GameManager
    {
        public Text looserText1;
        public GameManager gameManager;
        void Start()
        {
            isFinish = true;
            looserText1 = GetComponent<Text>();
            Debug.Log( looserText1 );
            looserText1.text = "player";
            gameManager = GameObject.Find("Score").GetComponent<GameManager>();
            looserText1.text = "player" + gameManager.GetLooser().GetComponent<FirstPersonController>().playerNumber + ", vous avez Gagné !";
        }
         
    }
}