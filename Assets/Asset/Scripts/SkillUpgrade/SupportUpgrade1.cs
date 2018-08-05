using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportUpgrade1 : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 1;
        effectDescription = "Remove random debuff from self";
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
        for(int i =0;i<user.GetComponent<PlayerVariableManager>().statusList.Count;i++)
        {
            if(user.GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>().type == "Bad")
            {
                user.GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>().secondDuration = 0;
                break;
            }
        }
    }
}
