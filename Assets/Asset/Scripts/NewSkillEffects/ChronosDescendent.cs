using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronosDescendent : SkillEffect
{
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.DEBUFF;
        numOfTarget = 0;
        effectDescription = "Buff all allies";
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
    
        for(int x= 0;x<playerList.Count;x++)
        {
            for(int y =0;y<status.Count;y++)
            {
                playerList[x].GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(status[y]));
            }
        }
        AudioManager.instance.PlaySound("TimePriestressAttackSound");
    }
}
