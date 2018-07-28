using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritDoorDoorToHell : SkillEffect {

    [SerializeField]int heal;
    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        user.GetComponent<EnemyTakeDamage>().EnemyHeal(heal);
        int totalDamage = (int)(damage * DamageMultiplier());
        for (int i = 0; i < playerList.Count; i++)
        {
            playerList[i].GetComponent<PlayerTakeDamage>().PlayerDamage(totalDamage);
            if (!playerList[i].GetComponent<PlayerStats>().immune)
            {
                for (int j = 0; j < status.Count; j++)
                {
                    playerList[i].GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(status[j]));
                }
            } 
        }
    }
}
