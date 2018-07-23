using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysicalDamage : SkillEffect {

    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        effectDescription = "Deal physical damage to a single target";
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Execute(GameObject target)
    {
        damage = (int)user.GetComponent<EnemyStats>().strength - (int)(target.GetComponent<PlayerStats>().defense * 0.2f);
        target.GetComponent<PlayerStats>().health -= damage;
    }
}
