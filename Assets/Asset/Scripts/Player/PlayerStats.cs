using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : GeneralStats {

    [HideInInspector] public int aggro;
    [HideInInspector] public bool knockedOut;
    [HideInInspector] public int reviveAction;
    public bool autoRevive;
    [HideInInspector] public bool taunt;
    
	// Update is called once per frame
	void Update ()
    {
		if(health >= baseHealth)
        {
            health = baseHealth;
        }
	}

    public void Reset()
    {
        knockedOut = false;
        reviveAction = 0;
        taunt = false;
        silence = false;
        berserk = false;
        GetComponent<PlayerScrollSkill>().enabled = true;
        GetComponent<PlayerSkillChooseTarget>().enabled = true;
        GetComponent<PlayerSkillExecution>().enabled = true;
        GetComponent<actionTimeBar>().timeRequired = 3f;
        GetComponent<actionTimeBar>().startSelection = Random.Range(0,0.5f);
    }
}
