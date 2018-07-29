using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightLastStand : SkillEffect {

    [SerializeField] private int heal;
    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.HEAL;
        numOfTarget = 0;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        user.GetComponent<EnemyTakeDamage>().EnemyHeal(heal);
    }
}
