using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade2 : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
        damage = 100;
        effectDescription = "Damage All Enemy";
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
        for(int i=0;i<enemyList.Count;i++)
        {
            enemyList[i].GetComponent<EnemyTakeDamage>().EnemyDamage(damage);
        }
    }
}
