using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using Score;

namespace NamespaceGameManager{
    public class GameManager : MonoBehaviour
    {
        public int round;
        private float timeLeft;
        public bool isStarting, isFinish;
        private FirstPersonController fpsController1, fpsController2;
        private Shooting Shooting1,Shooting2;
        public GameObject winner, looser;
        private GameObject gameObjectPlayer1, gameObjectPlayer2;
        private ScoreText scoreText;
        // Start is called before the first frame update

        private void Awake(){
            DontDestroyOnLoad(this.gameObject);
        }

        void Start()
        {
            timeLeft = 5f;

            Shooting1 = GameObject.Find("colt1").GetComponent<Shooting>();
		    Shooting2 = GameObject.Find("colt2").GetComponent<Shooting>();

            gameObjectPlayer1 = GameObject.Find("FPSController1");
            gameObjectPlayer2 = GameObject.Find("FPSController2");
            fpsController1 = gameObjectPlayer1.GetComponent<FirstPersonController>();
		    fpsController2 = gameObjectPlayer2.GetComponent<FirstPersonController>();

            scoreText = GameObject.Find("Score").GetComponent<ScoreText>();
            isStarting = true;
            isFinish = false;

        }

        // Update is called once per frame
        void Update()
        {
            if (!isFinish){
                if (!isStarting){
                    scoreText.UpdateScoreText("Score J1 : " + fpsController1.score + " Score J2 : " + fpsController2.score + " Round n°" + round);
                    if (fpsController1.score >= 2 || fpsController2.score >= 2){
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
                        fpsController1.m_WalkSpeed = 5;
                        fpsController2.m_WalkSpeed = 5;
                        fpsController2.m_RunSpeed = 8f;
                        fpsController1.m_RunSpeed = 8f;
                    }
                }
            } else {
                countDown();
                if (timeLeft <= 0){
                    isFinish = false;
                    SceneManager.LoadScene("Map Barrel Town");
                    Destroy(gameObjectPlayer1);
                    Destroy(gameObjectPlayer2);
                    Destroy(GameObject.Find("GameManager"));
                }
            }
        }

        void Win()
        {

            if(fpsController1.score >= 2 ){
                winner = gameObjectPlayer1;
                looser = gameObjectPlayer2;

            } else if(fpsController2.score >= 2) {
                looser = gameObjectPlayer1;
                winner = gameObjectPlayer2;
            }

            fpsController2.score = 0;
            fpsController1.score = 0;
           FinishScene();
        }
        public void ResetRound(FirstPersonController winner){
            countDown();
            fpsController1.ReturnToSpawn();
            fpsController2.ReturnToSpawn();
            winner.score ++;
			round++;
			Shooting1.Ammo = 4;
			Shooting2.Ammo = 4;
            isFinish = false;
            isStarting = true;
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
            fpsController1.m_WalkSpeed = 0f;
            fpsController1.m_Jump = false;
            fpsController2.m_Jump = false;
            fpsController2.m_RunSpeed = 0f;
            fpsController1.m_RunSpeed = 0f;
            fpsController2.m_WalkSpeed = 0f;
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
                player.GetComponent<FirstPersonController>().m_Camera.enabled = false;
                player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
                player.GetComponent<FirstPersonController>().m_Jump = false;
                 player.GetComponent<FirstPersonController>().m_RunSpeed = 0f;
                Destroy(player.GetComponent<Crouch>());
                Destroy(player.GetComponent<Trap>());
            }

            looser.transform.position = new Vector3(-2.57f, -0.61f, -1.88f);
            winner.transform.position = new Vector3(3.23f, 2.2f, -1.88f);
            looser.transform.rotation = Quaternion.Euler(0,180,0);
            winner.transform.rotation = Quaternion.Euler(0,0,0);
            Physics.SyncTransforms();

            GameObject.Find("FirstPersonCharacter").transform.rotation = Quaternion.Euler(0,0,0);

        }

    }
}