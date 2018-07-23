using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLockInSkill : PlayerVariableManager
{
    SkillDetail skillDetail;
    GameObject skill3;

    /*private void Awake()
    {
        playerTransform = this.GetComponent<Transform>();
       //lockInSkill = this.GetComponent<PlayerVariableManager>().lockInSkill; 
        battleLogScript = this.GetComponent<PlayerVariableManager>().battleLogScript;
        //chooseSkillBar.transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3(playerTransform.position.x - this.GetComponent<PlayerVariableManager>().barXOffset, playerTransform.position.y - this.GetComponent<PlayerVariableManager>().barYOffset, playerTransform.position.z));
    }

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<PlayerVariableManager>().holdTimerInPercentage = this.GetComponent<PlayerVariableManager>().holdTimer / this.GetComponent<PlayerVariableManager>().timeNeeded;
        this.GetComponent<PlayerVariableManager>().chooseSkillBar.fillAmount = this.GetComponent<PlayerVariableManager>().holdTimerInPercentage;

        chooseSkillBar.transform.localPosition = Camera.main.WorldToScreenPoint(new Vector3(playerTransform.position.x - this.GetComponent<PlayerVariableManager>().barXOffset, playerTransform.position.y - this.GetComponent<PlayerVariableManager>().barYOffset, playerTransform.position.z));

        if (this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.CHOOSING_SKILL)
        {
            if (Input.GetButton(this.GetComponent<PlayerVariableManager>().playerButton))
            {
                skillDetail = this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count / 2].GetComponent<SkillDetail>();
                skill3 = this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count / 2];
                if (skillDetail.skillCooldown > 0)
                {
                    battleLogScript.AddEvent(skill3.name + " is still under cooldown!!");
                }
                else
                {
                    this.GetComponent<PlayerVariableManager>().holdTimer += Time.deltaTime;
                    if (this.GetComponent<PlayerVariableManager>().holdTimer >= this.GetComponent<PlayerVariableManager>().timeNeeded)
                    {
                        this.GetComponent<PlayerVariableManager>().lockInSkill = this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count / 2];
                        this.GetComponent<PlayerVariableManager>().isSkillLockedIn = true;
                        //this.GetComponent<PlayerVariableManager>().holdTimer = 0f;
                        this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState = BattleStateManager.GAMESTATE.CHOOSING_TARGET;
                    }
                }                
            }
            else
            {
                this.GetComponent<PlayerVariableManager>().holdTimer = 0f;
            }
        }
        if (this.GetComponent<PlayerVariableManager>().isSkillLockedIn && GetComponent<actionTimeBar>().startSelection < 100f)
        {
            this.GetComponent<PlayerVariableManager>().lockedInTimer += Time.deltaTime;
        }
    }*/
}
