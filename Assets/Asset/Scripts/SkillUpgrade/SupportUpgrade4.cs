using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportUpgrade4 : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 1;
        effectDescription = "Chance to apply bless";
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
        if(Random.Range(0,101)<=20)
        {
            user.GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(status[0]));
        }
    }
}
