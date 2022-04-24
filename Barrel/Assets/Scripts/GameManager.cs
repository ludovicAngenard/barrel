using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player_controller;
using UnityEngine.SceneManagement;
using Score;
using UnityEngine.UI;

namespace NamespaceGameManager{
    class GameManager : MonoBehaviour
    {
        public int round = 1;
        private float timeLeft;
        public bool isStarting, isFinish;
        public PlayerController player1, player2;
        private Shooting Shooting1,Shooting2;
        public GameObject winner, looser;
        private GameObject gameObjectPlayer1, gameObjectPlayer2;
        private ScoreText scoreText;
        // Start is called before the first frame update

        void Start()
        {
            timeLeft = 5f;

            Shooting1 = GameObject.Find("colt1").GetComponent<Shooting>();
		    Shooting2 = GameObject.Find("colt2").GetComponent<Shooting>();

            gameObjectPlayer1 = GameObject.Find("PlayerParent1");
            gameObjectPlayer2 = GameObject.Find("PlayerParent2");
            isStarting = true;
            isFinish = false;

            scoreText = GameObject.Find("Round").GetComponent<ScoreText>();

        }

        // Update is called once per frame
        void Update()
        {
            if (!isFinish){
                if (!isStarting){
                    scoreText.UpdateScoreText("Round : "+ this.round);
                    if (player1.getScore() >= 2 || player2.getScore() >= 2){

                        isFinish = true;

                        Win();
                    }
                } else {

                    PlayersImmobility();
                    countDown();
                    if (timeLeft > 0){
                        scoreText.UpdateScoreText(timeLeft.ToString("0"));
                        isStarting = true;
                    } else {
                        isStarting = false;
                    }
                }
            } else {
                isStarting = false;
                countDown();
                if (timeLeft <= 0){
                    isFinish = false;
                    SceneManager.LoadScene("Menu2");
                    Destroy(gameObjectPlayer1);
                    Destroy(gameObjectPlayer2);
                    Destroy(GameObject.Find("GameManager"));
                }
            }
        }

        void Win()
        {

            if(player1.getScore() >= 2 ){
                winner = gameObjectPlayer1;
                looser = gameObjectPlayer2;

            } else if(player2.getScore() >= 2) {
                looser = gameObjectPlayer1;
                winner = gameObjectPlayer2;
            }

            player2.setScore(0);
            player1.setScore(0);

           Debug.Log("winnerX"+winner);
           Debug.Log("looserX"+looser);
           FinishScene();

        }
        public void ResetRound(PlayerController looserRound){
            countDown();
            player1.ReturnToSpawn();
            player2.ReturnToSpawn();
			round++;
			Shooting1.Ammo = 4;
			Shooting2.Ammo = 4;
            gameObjectPlayer1.GetComponent<Trap>().TrapCount = 1;
            gameObjectPlayer2.GetComponent<Trap>().TrapCount = 1;
            isFinish = false;
            isStarting = true;

            if(player1.getPlayerNumber() == looserRound.getPlayerNumber())
            {
                player2.setScore(player2.getScore() + 1);
            }
            else
            {
                player1.setScore(player1.getScore() + 1);
            }

        }

        public GameObject GetWinner()
        {
            return winner;
        }

        public GameObject GetLooser()
        {
            return looser;
        }
        public void PlayersImmobility(){
            player1.jumped = false;
            player2.jumped = false;
            player1.setPlayerSpeed(0);
        }
        public void countDown(){
            if (timeLeft >= 0){
                timeLeft -= Time.deltaTime;
            }
            else {
                timeLeft = 5;

            }
        }
        void FinishScene(){
            SceneManager.LoadScene("finish");

            GameObject[] players = {winner, looser};
            foreach (var player in players)
            {
                player.GetComponent<Camera>().enabled = false;
                player.GetComponent<PlayerController>().setPlayerSpeed(0f);
                player.GetComponent<PlayerController>().jumped = false;

            }

            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Crosshair")){
            Destroy(gameObj);
            }

            looser.transform.position = new Vector3(-2.57f, -0.61f, -1.88f);
            winner.transform.position = new Vector3(3.23f, 2.2f, -1.88f);
            gameObjectPlayer1.transform.rotation = Quaternion.Euler(0,180,0);
            gameObjectPlayer2.transform.rotation = Quaternion.Euler(0,0,0);
            Physics.SyncTransforms();

            GameObject.Find("PlayerParent").transform.rotation = Quaternion.Euler(0,0,0);

        }

    }
}