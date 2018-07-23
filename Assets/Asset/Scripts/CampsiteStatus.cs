using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CampsiteStatus : MonoBehaviour {

    public Text player1Health;
    public Text player1Strength;

    void Awake()
    {
        //player1Health.text = "Health : " + (PlayerPrefs.GetInt("P1 HP").ToString());
        //player1Strength.text = "Strenght : " + (PlayerPrefs.GetInt("P1 STR").ToString());
        player1Health.text = "Health : " + (PlayerPrefs.GetInt("P1 HP").ToString()) + "\n" + "Strenght : " + (PlayerPrefs.GetInt("P1 STR").ToString());
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
