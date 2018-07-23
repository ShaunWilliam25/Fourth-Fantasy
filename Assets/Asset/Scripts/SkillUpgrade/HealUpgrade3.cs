using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpgrade3 : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.HEAL;
        numOfTarget = 1;
        damage = 0;
        effectDescription = "Heal Self based on bad statuses";
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
       for(int i=0;i<user.GetComponent<PlayerVariableManager>().statusList.Count;i++)
       {
            if(user.GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>().type == "Bad")
            {
                damage += 50;
            }
       }
        user.GetComponent<PlayerTakeDamage>().PlayerHeal(damage);
    }
}
