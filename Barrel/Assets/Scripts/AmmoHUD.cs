// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class AmmoHUD : MonoBehaviour
// {
//     Text ammoText;
//     private Shooting Ammo1,Ammo2;
//     // Start is called before the first frame update
//     void Start()
//     {
//         Ammo1 = GameObject.Find("colt1").GetComponent<Shooting>();
//         Ammo2 = GameObject.Find("colt2").GetComponent<Shooting>();

//         ammoText = GetComponent<Text>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (gameObject.tag == "player1"){
//            ammoText.text = "Ammo : " + Ammo1.Ammo+"/4";

//         }


//         if (gameObject.tag == "player2"){
//            ammoText.text = "Ammo : " + Ammo2.Ammo+"/4";
//         }

//     }
//     // A voir écrire reload lors du reload
// }
