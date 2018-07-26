using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollen : SkillEffect
{

    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.DEBUFF;
        numOfTarget = 0;
        effectDescription = "Poison and debuff all enemies";
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
        for (int i = 0; i < enemyList.Count; i++)
        {
           if(!enemyList[i].GetComponent<EnemyStats>().immune)
           {
                for (int j = 0; j < status.Count; j++)
                {
                    enemyList[i].GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[j]));
                }
           }
            playerArtifact.ArtifactAttackEffect(enemyList[i]);
        }
        audioManager.PlaySound("TimePriestressAttackSound");
    }
}
