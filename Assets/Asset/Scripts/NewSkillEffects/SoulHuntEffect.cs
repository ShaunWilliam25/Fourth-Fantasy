using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulHuntEffect : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.DEBUFF;
        numOfTarget = 1;
        effectDescription = "Apply random debuff";
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
        if(!targetedEnemy.GetComponent<EnemyStats>().immune)
        {
            int rand = Random.Range(0, 3);
            targetedEnemy.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[rand]));
        }

        AudioManager.instance.PlaySound("ExiledDemonAttackSound");
    }
}
