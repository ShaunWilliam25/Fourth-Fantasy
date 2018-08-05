using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade1 : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        damage = 150;
        effectDescription = "Damage Single Enemy";
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Execute(GameObject targetedEnemy)
    {
        damage = (int)(damage * DamageMultiplier());
        targetedEnemy.GetComponent<EnemyTakeDamage>().EnemyDamage(damage);
    }
}
