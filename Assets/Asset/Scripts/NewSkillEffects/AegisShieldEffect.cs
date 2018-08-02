using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AegisShieldEffect : SkillEffect {

    [SerializeField] private GameObject selfTaunt;
    private void Awake()
    {
        AssignUser();
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
        effectDescription = "Taunts enemy and buff allies";
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
        user.GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(selfTaunt));
        for(int i = 0;i<playerList.Count;i++)
        {
            playerList[i].GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(status[0]));
        }
    }
}
