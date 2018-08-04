using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanRushEffect : SkillEffect {

    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        effectDescription = "Attacks and haste self";
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
        user.GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(status[0]));
        int totalDamage = (int)((damage + DamageAddOn()) * DamageMultiplier());
        targetedEnemy.GetComponent<EnemyTakeDamage>().EnemyDamage(totalDamage);
        playerArtifact.ArtifactAttackEffect(targetedEnemy);

        AudioManager.instance.PlaySound("ExiledDemonAttackSound");
    }
}
