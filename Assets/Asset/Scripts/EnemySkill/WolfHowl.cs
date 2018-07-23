using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHowl : SkillEffect
{
    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        //Summon Wolf(Dunno how to do yet)
    }
}
