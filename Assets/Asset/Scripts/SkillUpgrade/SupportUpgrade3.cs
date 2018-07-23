using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportUpgrade3 : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.DEBUFF;
        numOfTarget = 1;
        effectDescription = "Remove random buff from enemy";
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Execute(GameObject targetedEnemy)
    {
        for (int i = 0; i < targetedEnemy.GetComponent<EnemyVariableManager>().statusList.Count; i++)
        {
            if (targetedEnemy.GetComponent<EnemyVariableManager>().statusList[i].GetComponent<StatusDetail>().type == "Good")
            {
                targetedEnemy.GetComponent<EnemyVariableManager>().statusList[i].GetComponent<StatusDetail>().secondDuration = 0;
                break;
            }
        }
    }
}
