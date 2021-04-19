using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TrapHUD : MonoBehaviour
{
    Text trapText;
    private FirstPersonController player1,player2;
    // Start is called before the first frame update
    void Start()
    {
        trapText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        player1 = GameObject.Find("FPSController1").GetComponent<FirstPersonController>();
        player2 = GameObject.Find("FPSController2").GetComponent<FirstPersonController>();
        

        if (gameObject.tag == "player1"){
           trapText.text = "Trap : " + player1.GetComponent<Trap>().TrapCount+"/1";   

        }

        if (gameObject.tag == "player2"){
           trapText.text = "Trap : " + player2.GetComponent<Trap>().TrapCount+"/1";   

        }

    }
}
