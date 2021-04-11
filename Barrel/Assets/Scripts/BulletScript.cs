using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using  NamespaceGameManager;



public class BulletScript : MonoBehaviour {

	private GameManager GameManager;

	// Use this for initialization
	void Start () {


		GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter(Collision collision)
    {

		if (collision.gameObject.tag == "player1" || collision.gameObject.tag == "player2")
    	{
			GameManager.ResetRound(collision.gameObject.GetComponent<FirstPersonController>());

			Destroy(GameObject.FindWithTag("trap"));
    	}

		Debug.Log("YES collision : " + collision);
		Destroy(this);
    }
}
