using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpgrade4 : SkillEffect
{
    bool effect;
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.HEAL;
        numOfTarget = 1;
        effect = false;
        effectDescription = "Gain instant revive one time";
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
        if(!effect)
        {
            user.GetComponent<PlayerStats>().autoRevive = true;
            effect = true;
        }
    }
}
