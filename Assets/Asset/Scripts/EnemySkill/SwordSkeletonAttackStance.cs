using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkeletonAttackStance : SkillEffect {

    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 1;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        for(int i =0;i<status.Count;i++)
        {
            user.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[i]));
        }
        
    }
}
