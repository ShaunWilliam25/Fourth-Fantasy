using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulHuntEffect : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        damage = 50;
        effectDescription = "Deal damage and apply random debuff";
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
        if(!targetedEnemy.GetComponent<EnemyStats>().immune)
        {
            int rand = Random.Range(0, 3);
            targetedEnemy.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[rand]));
            Debug.Log("Applied " + status[rand]);
        }
        
        audioManager.PlaySound("ExiledDemonAttackSound");
    }
}
