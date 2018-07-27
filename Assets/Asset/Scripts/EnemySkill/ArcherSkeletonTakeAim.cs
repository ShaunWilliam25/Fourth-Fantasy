using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkeletonTakeAim : SkillEffect {

    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 1;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        user.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[0]));
    }
}
