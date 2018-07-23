using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronosDescendent : SkillEffect
{
    [SerializeField]List<GameObject> buff;
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        damage = 20;
        numOfTarget = 0;
        effectDescription = "Strong buff to allies and strong debuff to enemies";
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
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[0]));
            enemyList[i].GetComponent<EnemyTakeDamage>().EnemyDamage(damage);
        }
        for(int x= 0;x<playerList.Count;x++)
        {
            for(int y =0;y<buff.Count;y++)
            {
                playerList[x].GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(buff[y]));
            }
        }
        audioManager.PlaySound("TimePriestressAttackSound");
    }
}
