using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpgrade3 : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.HEAL;
        numOfTarget = 1;
        damage = 0;
        effectDescription = "Heals 50 HP for each bad status effect on character";
    }

    public override void Execute(GameObject targetedEnemy)
    {
        for(int i=0;i<user.GetComponent<PlayerVariableManager>().statusList.Count;i++)
        {
            if(user.GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>().type == "Bad")
            {
                damage += 50;
            }
        }
        if (user.GetComponent<PlayerStats>().health + damage > user.GetComponent<PlayerStats>().baseHealth)
        {
            user.GetComponent<PlayerTakeDamage>().PlayerHeal(Mathf.RoundToInt(user.GetComponent<PlayerStats>().baseHealth - user.GetComponent<PlayerStats>().health));
        }
        else
        {
            user.GetComponent<PlayerTakeDamage>().PlayerHeal(damage);
        }
    }
}
