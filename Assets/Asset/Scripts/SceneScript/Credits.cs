using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public Animator creditAnim;
    float timer;
    [SerializeField]float duration = 15f;
    string skipButton;
    
    // Use this for initialization
	void Start ()
    {
        creditAnim.Play("creditsAnimation");
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= duration)
        {
            timer = 0f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        if(Input.anyKeyDown)
        {
            timer = 0f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }
}
