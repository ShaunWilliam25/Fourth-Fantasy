using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackOldGuard : SkillEffect {

    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        effectDescription = "Attack frontline enemy";
    }

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }


    public override void Execute(GameObject targetedEnemy)
    {
        int totalDamage = (int)(damage * DamageMultiplier());
        targetedEnemy.GetComponent<EnemyTakeDamage>().EnemyDamage(totalDamage);
        playerArtifact.ArtifactAttackEffect(targetedEnemy);
        audioManager.PlaySound("OldGuardAttackSound");
    }
}
