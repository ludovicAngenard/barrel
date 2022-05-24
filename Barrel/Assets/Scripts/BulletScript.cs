using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using player_controller;
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
		Debug.Log(collision.gameObject);
		if (collision.gameObject.tag == "player1" || collision.gameObject.tag == "player2")
    	{
			GameManager.ResetRound(collision.gameObject.GetComponent<PlayerController>());

			Destroy(GameObject.FindWithTag("trap"));
    	}
		Destroy(GameObject.Find("Sphere(Clone)"));
    }
}
