using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace NamespaceGameManager{
    public class GameManager : MonoBehaviour
    {

        private Text scoreText;
        public int round;
        private float timeLeft;
        private int unlock;
        public bool isStarting, isFinish;
        private FirstPersonController player1, player2;
        private Shooting Shooting1,Shooting2;
        public GameObject winner, looser;
        private GameObject gameObjectPlayer1, gameObjectPlayer2;
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
            player1 = gameObjectPlayer1.GetComponent<FirstPersonController>();
		    player2 = gameObjectPlayer2.GetComponent<FirstPersonController>();

            scoreText = GetComponent<Text>();
            unlock = 0;
            isStarting = true;
            isFinish = false;

        }

        // Update is called once per frame
        void Update()
        {
            if (!isFinish){
                if (!isStarting){
                    unlock ++;
                    if (unlock == 1){
                        player1.m_WalkSpeed = 5;
                        player2.m_WalkSpeed = 5;
                    }
                    scoreText.text = "Score J1 : " + player1.score + " Score J2 : " + player2.score + " Round n°" + round;
                    if (player1.score == 2 || player2.score == 2){
                        isFinish = true;
                        Win();
                    }
                } else {
                    countDown();
                    player1.m_WalkSpeed = 0f;
                    player1.m_Jump = false;

                    player2.m_Jump = false;
                    player2.m_WalkSpeed = 0f;
                }
            }
        }

        void Win()
        {

            if(player1.score == 2 ){
                winner = gameObjectPlayer1;
                looser = gameObjectPlayer2;

            } else if(player2.score == 2) {
                looser = gameObjectPlayer1;
                winner = gameObjectPlayer2;
            }

            player2.score = 0;
            player1.score = 0;
            SceneManager.LoadScene("finish");
            winner.GetComponent<FirstPersonController>().m_Camera.enabled = false;
            looser.GetComponent<FirstPersonController>().m_Camera.enabled = false;
            Destroy(GameObject.Find("FPSController2").GetComponent<MeshCollider>());
            Destroy(GameObject.Find("FPSController2").GetComponent<CapsuleCollider>());
            Destroy(GameObject.Find("FPSController2").GetComponent<Rigidbody>());
            Destroy(GameObject.Find("FPSController2").GetComponent<Crouch>());
            Destroy(GameObject.Find("FPSController2").GetComponent<Trap>());
            Destroy(GameObject.Find("FPSController2").GetComponent<FirstPersonController>());
            Destroy(GameObject.Find("FPSController2").GetComponent<CharacterController>());
            Destroy(GameObject.Find("FPSController1").GetComponent<MeshCollider>());
            Destroy(GameObject.Find("FPSController1").GetComponent<CapsuleCollider>());
            Destroy(GameObject.Find("FPSController1").GetComponent<Rigidbody>());
            Destroy(GameObject.Find("FPSController1").GetComponent<Crouch>());
             Destroy(GameObject.Find("FPSController1").GetComponent<Trap>());
            Destroy(GameObject.Find("FPSController1").GetComponent<FirstPersonController>());
            Destroy(GameObject.Find("FPSController1").GetComponent<CharacterController>());
            looser.transform.position = new Vector3(-2.57f, -0.61f, -1.88f);
            winner.transform.position = new Vector3(3.23f, 2.2f, -1.88f);
            looser.transform.rotation = Quaternion.Euler(0,180,0);
            winner.transform.rotation = Quaternion.Euler(0,180,0);
            GameObject.Find("FirstPersonCharacter").transform.rotation = Quaternion.Euler(0,0,0);

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
                scoreText.text = (timeLeft).ToString("0");
            }
            else {
                isStarting = false;
                timeLeft = 5;

            }
        }
    }
}