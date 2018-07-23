using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : PlayerVariableManager {

    private void Awake()
    {
       
    }

    // Use this for initialization
    void Start ()
    {
        this.GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(idleAnimation);
    }
	
	// Update is called once per frame
	void Update ()
    {

	}
}
