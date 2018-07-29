using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriesOfTheDemon : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.DEBUFF;
        numOfTarget = 1;
        effectDescription = "Debuff all enemies";
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
        for(int i=0;i<enemyList.Count;i++)
        {
            if(enemyList[i].GetComponent<EnemyStats>().immune)
            {
                for (int j = 0; j < status.Count; j++)
                {
                    enemyList[i].GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[j]));
                }
            }
        }
        audioManager.PlaySound("ExiledDemonAttackSound");


    }
}
