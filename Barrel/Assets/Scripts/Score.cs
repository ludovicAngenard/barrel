using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

namespace NamespaceScore{
    public class Score : MonoBehaviour
    {

        Text scoreText, startTimer;
        public int round;
        private float timeLeft;
        private bool isStarting;
        private FirstPersonController player1, player2;
        private Shooting Shooting1,Shooting2;
        // Start is called before the first frame update
        void Start()
        {
            timeLeft = 5f;
            Shooting1 = GameObject.Find("colt1").GetComponent<Shooting>();
		    Shooting2 = GameObject.Find("colt2").GetComponent<Shooting>();

            player1 = GameObject.Find("FPSController1").GetComponent<FirstPersonController>();
		    player2 = GameObject.Find("FPSController2").GetComponent<FirstPersonController>();

            scoreText = GetComponent<Text>();
            startTimer = GetComponent<Text>();

            isStarting = true;

        }

        // Update is called once per frame
        void Update()
        {
            if (!isStarting){
                scoreText.text = "Score J1 : " + player1.score + " Score J2 : " + player2.score + " Round n°" + round;
                Win();
            } else {
                countDown();
            }


        }

        void Win()
        {

                if(player1.score == 2)
                {
                    Debug.Log("Joueur 1 Gagnant !");
                }
                if(player2.score == 2)
                {
                    Debug.Log("Joueur 2 Gagnant !");
                }

        }
        public void ResetRound(FirstPersonController winner){
            countDown();
            player1.ReturnToSpawn();
            player2.ReturnToSpawn();
            winner.score ++;
			round++;
			Shooting1.Ammo = 4;
			Shooting2.Ammo = 4;
        }
        public void countDown(){
            if (timeLeft >= 0){
                isStarting = true;
                timeLeft -= Time.deltaTime;
                Debug.Log(timeLeft);
                startTimer.text = (timeLeft).ToString("0");
            }
            else {
                isStarting = false;
                timeLeft = 5;
            }
        }
    }
}