using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SkillEffect {

    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
        damage = 50;
        effectDescription = "Attack and burn all enemy";
    }

    // Use this for initialization
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Execute(GameObject targetedEnemy)
    {
        damage = (int)(damage * DamageMultiplier());
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[0]));
            enemyList[i].GetComponent<EnemyTakeDamage>().EnemyDamage(damage);
        }
        audioManager.PlaySound("TimePriestressAttackSound");
    }
}
