using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceSkeletonNormalAttack : SkillEffect {

    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        int totalDamage = (int)(damage * DamageMultiplier());
        targetedEnemy.GetComponent<PlayerTakeDamage>().PlayerDamage(totalDamage);
    }
}
