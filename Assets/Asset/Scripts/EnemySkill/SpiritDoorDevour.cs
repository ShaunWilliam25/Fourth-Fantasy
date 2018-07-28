using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritDoorDevour : SkillEffect {

    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        int totalDamage = (int)(damage * DamageMultiplier());
        targetedEnemy.GetComponent<PlayerTakeDamage>().PlayerDamage(totalDamage);
        if(!targetedEnemy.GetComponent<PlayerStats>().immune)
        {
            for (int i = 0; i < status.Count; i++)
            {
                targetedEnemy.GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(status[i]));
            }
        }
    }
}
