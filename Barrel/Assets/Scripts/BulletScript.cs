using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  NamespaceScore;
using UnityStandardAssets.Characters.FirstPerson;

public class BulletScript : MonoBehaviour {

	private Score Score;

	// Use this for initialization
	void Start () {


		Score = GameObject.Find("Score").GetComponent<Score>();
	}

	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter(Collision collision)
    {

		if (collision.gameObject.tag == "player1" || collision.gameObject.tag == "player2")
    	{
			Score.ResetRound(collision.gameObject.GetComponent<FirstPersonController>());

			Destroy(GameObject.FindWithTag("trap"));

    	}

		Destroy(this);
    }
}
