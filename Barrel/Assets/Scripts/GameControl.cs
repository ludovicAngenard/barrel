// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// namespace NamespaceGameControl{
// public class GameControl : MonoBehaviour
// {
//     public static bool gameIsPaused = false;
//     [SerializeField] GameObject pauseMenu;

//     // Start is called before the first frame update
//     void Start()
//     {
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Escape))
//         {
//             if(gameIsPaused)
//             {
//                 ResumeGame();
//             }
//             else
//             {
//                 pauseMenu.SetActive(true);
//                 PauseGame();
//             }
//         }
//     }

//     public void ResumeGame()
//     {

//         pauseMenu.SetActive(false);
//         Time.timeScale = 1f;
//         gameIsPaused = false;

//     }

//     public void PauseGame ()
//     {
//         pauseMenu.SetActive(true);
//         Time.timeScale = 0f;
//         gameIsPaused = true;
//     }

//     public void QuitGame()
//     {
//         ResumeGame();
//         GameObject[] players = {GameObject.Find("FPSController1"), GameObject.Find("FPSController2")};
//             foreach (var player in players)
//             {
//                 Destroy(player);


//             }

//             Destroy(GameObject.Find("GameManager"));

//         SceneManager.LoadScene("Menu2");
//     }



// }
// }
