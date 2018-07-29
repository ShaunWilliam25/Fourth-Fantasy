using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyOfOneEffect : SkillEffect {

    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
        effectDescription = "Buff All Allies";
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
        for (int i = 0; i < playerList.Count; i++)
        {
            for(int j=0;j<status.Count;j++)
            {
                playerList[i].GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(status[j]));
            }
        }

        audioManager.PlaySound("ExiledDemonAttackSound");
    }
}
