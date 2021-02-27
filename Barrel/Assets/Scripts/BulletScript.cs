using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using static Score;


public class BulletScript : MonoBehaviour {
	
	private Shooting Shooting1,Shooting2;

	// Use this for initialization
	void Start () {
		Shooting1 = GameObject.Find("colt1").GetComponent<Shooting>();
		Shooting2 = GameObject.Find("colt2").GetComponent<Shooting>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter(Collision collision)
    {
		
		if (collision.gameObject.tag == "player1")
    	{
       		Destroy(collision.gameObject);
			Score.score2++;
			Score.round++;
			Destroy(GameObject.FindWithTag("trap"));
			
			Shooting1.Ammo = 4;
			Shooting2.Ammo = 4;
			
    	}
		
		if (collision.gameObject.tag == "player2")
		{
       		Destroy(collision.gameObject);
			Score.score1++;
			Score.round++;
			Destroy(GameObject.FindWithTag("trap"));
		}
		
		
    }




}
