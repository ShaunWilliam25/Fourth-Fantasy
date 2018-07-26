using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackTimePrietess : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        damage = 40;
        effectDescription = "Attack backline enemy";
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
        enemyList[enemyList.Count-1].GetComponent<EnemyTakeDamage>().EnemyDamage(totalDamage);
        playerArtifact.ArtifactAttackEffect(enemyList[enemyList.Count - 1]);
        audioManager.PlaySound("TimePriestressAttackSound");
    }
}
