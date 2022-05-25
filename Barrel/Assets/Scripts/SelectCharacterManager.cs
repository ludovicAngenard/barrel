using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectCharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btnStart = GameObject.Find("Start").GetComponent<Button>();
		btnStart.onClick.AddListener(TaskOnClick);

        Button btnMenu = GameObject.Find("MenuButton").GetComponent<Button>();
		btnMenu.onClick.AddListener(BackMenu);

    }

    void BackMenu(){

		SceneManager.LoadScene("Menu2");
	}

    void TaskOnClick(){

		SceneManager.LoadScene("Map Barrel Town2");
	}
}
