using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpgrade1 : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.HEAL;
        numOfTarget = 1;
        damage = 100;
        effectDescription = "Heal Self";
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
        if(damage > (user.GetComponent<PlayerStats>().baseHealth - user.GetComponent<PlayerStats>().health))
        {
            user.GetComponent<PlayerTakeDamage>().PlayerHeal(Mathf.RoundToInt(user.GetComponent<PlayerStats>().baseHealth - user.GetComponent<PlayerStats>().health));
        }
        else
        {
            user.GetComponent<PlayerTakeDamage>().PlayerHeal(damage);
        }
    }
}
