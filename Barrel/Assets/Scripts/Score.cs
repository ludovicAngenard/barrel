using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace NamespaceScore{
    public class Score : MonoBehaviour
    {

        Text scoreText, startTimer;
        public int round;
        private float timeLeft;
        private int unlock;
        public bool isStarting;
        private FirstPersonController player1, player2;
        private Shooting Shooting1,Shooting2;
        public FirstPersonController winner;
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
            unlock = 0;
            isStarting = true;

        }

        // Update is called once per frame
        void Update()
        {
            if (!isStarting){
                unlock ++;
                if (unlock == 1){
                    player1.m_WalkSpeed = 5;
                    player2.m_WalkSpeed = 5;
                }

                scoreText.text = "Score J1 : " + player1.score + " Score J2 : " + player2.score + " Round n°" + round;
                Win();
            } else {
                countDown();
                player1.m_WalkSpeed = 0f;
                player1.m_Jump = false;

                player2.m_Jump = false;
                player2.m_WalkSpeed = 0f;
            }


        }

        void Win()
        {

            if(player1.score == 2 ){
                winner = player1;
                player2.score = 0;
                player1.score = 0;
                SceneManager.LoadScene("finish");
            } else if(player2.score == 2) {
                winner = player2;
                player2.score = 0;
                player1.score = 0;
                SceneManager.LoadScene("finish");
            }


        }
        public void ResetRound(FirstPersonController winner){
            countDown();
            unlock = 0;
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