using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceOfTheDemon : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.HEAL;
        numOfTarget = 1;
        effectDescription = "Heal all allies";
    }

    // Use this for initialization
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Execute(GameObject targetedEnemy)
    {
        for(int i=0;i<playerList.Count;i++)
        {
            playerList[i].GetComponent<PlayerTakeDamage>().PlayerHeal((int)(playerList[i].GetComponent<PlayerStats>().baseHealth * 0.1f));
        }
        audioManager.PlaySound("HealSound");
    }
}
