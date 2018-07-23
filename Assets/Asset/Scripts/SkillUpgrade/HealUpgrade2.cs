using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpgrade2 : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.HEAL;
        numOfTarget = 1;
        damage = 50;
        effectDescription = "Heal all allies";
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
        for(int i=0;i<playerList.Count;i++)
        {
            playerList[i].GetComponent<PlayerTakeDamage>().PlayerHeal(damage);
        }
    }
}
