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
        void Start()
        {
            isFinish = true;
            looserText1 = GetComponent<Text>();
            Debug.Log( looserText1 );
            looserText1.text = "player";
            looserText1.text = "player" + looser.GetComponent<FirstPersonController>().playerNumber + ", vous avez Gagné !";
        }
         void ChangeText(){
              looserText1.text = looserText1.name + ", vous avez perdu !";
         }
    }
}