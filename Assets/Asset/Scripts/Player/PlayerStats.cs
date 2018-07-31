using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : GeneralStats {

    [HideInInspector] public int aggro;
    [HideInInspector] public bool knockedOut;
    [HideInInspector] public int reviveAction;
    [HideInInspector] public bool autoRevive;
    [HideInInspector] public bool taunt;
    
	// Update is called once per frame
	void Update ()
    {
		if(health >= baseHealth)
        {
            health = baseHealth;
        }
	}
}
