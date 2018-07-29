using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightRevengeOfTheFallenKnight : SkillEffect {

    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        user.GetComponent<EnemyTakeDamage>().EnemyHeal((int)(user.GetComponent<EnemyStats>().baseHealth * 0.4f));
        for(int i =0;i<status.Count;i++)
        {
            user.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[i]));
        }
    }
}
