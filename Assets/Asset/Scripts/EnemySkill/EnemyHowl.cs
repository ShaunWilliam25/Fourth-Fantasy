using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHowl : SkillEffect {

    public GameObject wolf;
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
        effectDescription = "Summon a wolf to the battlefield(max of 3 enemies)";
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Execute(GameObject target)
    {
        /*if(user.GetComponent<EnemyVariableManager>().SceneManager.enemyList.Count <3)
        {
            for(int i=0;i<)
        }*/
    }
}
