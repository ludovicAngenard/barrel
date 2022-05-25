using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickMenu : MonoBehaviour {


	void Start () {
        Button btnSelectChar = GameObject.Find("CharaSelect").GetComponent<Button>();
		btnSelectChar.onClick.AddListener(LoadSelectCharScene);

		//Button btnStart = GameObject.Find("Start").GetComponent<Button>();
		//btnStart.onClick.AddListener(TaskOnClick);

        Button btnQuit = GameObject.Find("Quit").GetComponent<Button>();
        btnQuit.onClick.AddListener(QuitApplication);
	}



    void QuitApplication(){

        UnityEditor.EditorApplication.isPlaying = false;
    }

	//void TaskOnClick(){
    //
	//	SceneManager.LoadScene("Map Barrel Town2");
	//}

    void LoadSelectCharScene(){

		SceneManager.LoadScene("CharacterSelection");
	}
}