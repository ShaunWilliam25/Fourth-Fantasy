using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade4 : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        damage = 130;
        effectDescription = "Damage and slow single enemy";
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
        targetedEnemy.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[0]));
    }
}
