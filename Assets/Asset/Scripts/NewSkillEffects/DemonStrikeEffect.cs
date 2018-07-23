using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonStrikeEffect : SkillEffect
{
    int heal;
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        damage = 70;
        heal = 30;
        effectDescription = "Damage enemy and heal self";
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
        targetedEnemy.GetComponent<EnemyTakeDamage>().EnemyDamage(damage);
        user.GetComponent<PlayerTakeDamage>().PlayerHeal(heal);
        audioManager.PlaySound("ExiledDemonAttackSound");
    }
}
