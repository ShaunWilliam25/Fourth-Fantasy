using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChangeScene : MonoBehaviour {
	
	void Update () {
		if(Input.GetKeyDown("g"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
	}
}
