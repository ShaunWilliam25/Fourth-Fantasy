using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriesOfTheDemon : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        damage = 40;
        effectDescription = "Deal damage and debuff all enemies";
    }

    // Use this for initialization
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Execute(GameObject targetedEnemy)
    {
        damage = (int)(damage * DamageMultiplier());
        for(int i=0;i<enemyList.Count;i++)
        {
            Debug.Log(enemyList.Count);
            enemyList[i].GetComponent<EnemyTakeDamage>().EnemyDamage(damage);
            for(int j=0;j<status.Count;j++)
            {
                enemyList[i].GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[j]));
            }
        }
        audioManager.PlaySound("ExiledDemonAttackSound");


    }
}
