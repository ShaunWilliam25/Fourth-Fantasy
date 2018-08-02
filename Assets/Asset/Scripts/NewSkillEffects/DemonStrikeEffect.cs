using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonStrikeEffect : SkillEffect
{
    [SerializeField]int heal;
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        effectDescription = "Damage enemy and heal self";
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
        targetedEnemy.GetComponent<EnemyTakeDamage>().EnemyDamage(totalDamage);
        playerArtifact.ArtifactAttackEffect(targetedEnemy);
        user.GetComponent<PlayerTakeDamage>().PlayerHeal(heal);
        AudioManager.instance.PlaySound("ExiledDemonAttackSound");
    }
}
