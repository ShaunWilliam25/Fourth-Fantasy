using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkeletonFlameShower : SkillEffect {

    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        damage = 50;
        numOfTarget = 0;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        int totalDamage = (int)(damage * DamageMultiplier());
        for(int i=0;i<playerList.Count;i++)
        {
            playerList[i].GetComponent<PlayerTakeDamage>().PlayerDamage(totalDamage);
            playerList[i].GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(status[0]));
        }
    }
}
