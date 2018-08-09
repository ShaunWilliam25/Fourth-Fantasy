using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    string skipButton;
    
    // Use this for initialization
	void Start ()
    {        
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.anyKeyDown)
        {
            artifactSpawnerSingleton.instance.GetComponent<ArtifactScript>().createdArtifactList.Clear();
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }
}
