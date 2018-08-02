using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SkillEffect {

    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
        effectDescription = "Attack and burn all enemy";
        upgradedTimes = 0;
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
        int totalDamage = (int)(damage * DamageMultiplier());
        for (int i = 0; i < enemyList.Count; i++)
        {
            if(!enemyList[i].GetComponent<EnemyStats>().immune)
            {
                enemyList[i].GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[0]));
            }
            playerArtifact.ArtifactAttackEffect(enemyList[i]);
            enemyList[i].GetComponent<EnemyTakeDamage>().EnemyDamage(totalDamage);
        }
        AudioManager.instance.PlaySound("TimePriestressAttackSound");
    }
}
