using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpgrade2 : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.HEAL;
        numOfTarget = 1;
        damage = 50;
        effectDescription = "Heals 50 HP to all allies";
    }

    public override void Execute(GameObject targetedEnemy)
    {
        for(int i=0;i<playerList.Count;i++)
        {
            if(playerList[i].GetComponent<PlayerStats>().health+damage > playerList[i].GetComponent<PlayerStats>().baseHealth)
            {
                playerList[i].GetComponent<PlayerTakeDamage>().PlayerHeal(Mathf.RoundToInt(playerList[i].GetComponent<PlayerStats>().baseHealth- playerList[i].GetComponent<PlayerStats>().health));
            }
            else
            {
                playerList[i].GetComponent<PlayerTakeDamage>().PlayerHeal(damage);
            }
        }
    }
}
