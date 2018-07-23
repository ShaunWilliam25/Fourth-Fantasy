using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFeedback : MonoBehaviour {

    public Button buttonA;
    public Button buttonL;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("a"))
        {
            buttonA.GetComponent<Image>().color = Color.white;
        }
        else
        {
            buttonA.GetComponent<Image>().color = Color.grey;
        }

        if (Input.GetKey("l"))
        {
            buttonL.GetComponent<Image>().color = Color.white;
        }
        else
        {
            buttonL.GetComponent<Image>().color = Color.grey;
        }
        
        
	}
}
