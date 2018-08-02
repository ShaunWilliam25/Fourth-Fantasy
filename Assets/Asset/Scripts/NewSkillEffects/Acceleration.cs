using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
        effectDescription = "Boost Team Action Speed";
        upgradedTimes = 0;
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
        for(int i=0;i<playerList.Count;i++)
        {
            playerList[i].GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(status[0]));
        }
        AudioManager.instance.PlaySound("TimePriestressAttackSound");
    }
}
