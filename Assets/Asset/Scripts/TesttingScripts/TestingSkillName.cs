using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingSkillName : MonoBehaviour {

    public GameObject player1;
	// Use this for initialization
	void Start () {
        player1 = Player1.instance.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.gameObject.GetComponent<Text>().text = player1.GetComponent<PlayerStats>().name;
	}
}
