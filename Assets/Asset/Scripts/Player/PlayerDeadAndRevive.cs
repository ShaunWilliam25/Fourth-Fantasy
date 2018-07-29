using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadAndRevive : MonoBehaviour {

    public PlayerStats playerStats;
    public PlayerVariableManager playerVariable;
    public Color originalColour;
	// Use this for initialization
	void Start ()
    {
        originalColour = GetComponentInChildren<SpriteRenderer>().color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerStats = GetComponent<PlayerStats>();
        playerVariable = GetComponent<PlayerVariableManager>();
        if (playerStats.health <= 0 && playerStats.knockedOut == false)
        {
            playerVariable.statusList.Clear();
            playerStats.knockedOut = true;
            playerStats.reviveAction = 3;
            playerVariable.GetComponent<PlayerScrollSkill>().enabled = false;
            playerVariable.GetComponent<PlayerSkillChooseTarget>().enabled = false;
            playerVariable.GetComponent<PlayerSkillExecution>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }
        if(playerStats.knockedOut)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }
        if(playerStats.knockedOut == true && playerStats.reviveAction <=0 || playerStats.autoRevive)
        {
            playerStats.knockedOut = false;
            playerStats.reviveAction = 0;
            playerStats.autoRevive = false;
            playerStats.health = playerStats.baseHealth;
            playerVariable.GetComponent<PlayerScrollSkill>().enabled = true;
            playerVariable.GetComponent<PlayerSkillChooseTarget>().enabled = true;
            playerVariable.GetComponent<PlayerSkillExecution>().enabled = true;
            GetComponentInChildren<SpriteRenderer>().color = originalColour;
        }
	}
}
