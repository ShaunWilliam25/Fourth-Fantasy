using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillExecution : PlayerVariableManager
{
    PlayerStatusUpdate statusUpdateScript;
    public int isAttack = 0;
    public float attackAnimationTimer;

    private void Awake()
    {

        actionTimerBarScript = this.GetComponent<actionTimeBar>();
        //statusUpdateScript = GetComponent<PlayerStatusUpdate>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (actionTimerBarScript.selectionBar.fillAmount >= 1)
        {
            if (this.GetComponent<PlayerVariableManager>().isTargetLockedIn)
            {
                this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState = BattleStateManager.GAMESTATE.EXECUTE_SKILL;
            }
        }
        if (this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.EXECUTE_SKILL)
        {
            for (int i = 0; i < this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count / 2].GetComponent<SkillDetail>().skillExecutionHolder.Count; i++)
            {
                //! Execute skill
                //this.GetComponent<PlayerVariableManager>().lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[i].GetComponent<SkillEffect>().Execute(this.GetComponent<PlayerVariableManager>().targetedEnemy);
                this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count / 2].GetComponent<SkillDetail>().skillExecutionHolder[i].GetComponent<SkillEffect>().Execute(this.GetComponent<PlayerVariableManager>().targetedEnemy);

                //! Update the battle log
                this.GetComponent<PlayerVariableManager>().battleLogScript.AddEvent(this.GetComponent<PlayerVariableManager>().playerStats.name + " " + this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count / 2].GetComponent<SkillDetail>().skillDescription);

                //! Check for tutorial 2
                isAttack++;
                /*if (this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count / 2].GetComponent<SkillDetail>().skillName == "Normal Attack")
                {
                    isAttack++;
                }*/

                this.GetComponent<PlayerVariableManager>().oriColor = this.GetComponent<PlayerVariableManager>().targetedEnemy.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                this.GetComponent<PlayerVariableManager>().targetedEnemy.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;                
                this.GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<PlayerVariableManager>().attackAnimation);
                Invoke("ResetColor", 0.2f);
                //Invoke("ResetMovement", 0.2f);
                Invoke("ResetAnimation", attackAnimationTimer);
            }

            //! Reducing skill cooldown
            /*for (int i = 0; i < GetComponent<PlayerVariableManager>().skillHolder.Count; i++)
            {
                if (GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SkillDetail>().skillCooldown > 0)
                {
                    GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SkillDetail>().skillCooldown--;
                }
            }*/

            //! Reducing action required to revive ally
            if(this.GetComponent<PlayerVariableManager>().allySpawnPoint.GetComponent<PlayerStats>().reviveAction > 0)
            {
                this.GetComponent<PlayerVariableManager>().allySpawnPoint.GetComponent<PlayerStats>().reviveAction--;
            }

            //! Set the cooldown for the skill used
            //GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count / 2].GetComponent<SkillDetail>().skillCooldown = GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count / 2].GetComponent<SkillDetail>().maxSkillCooldown;

            //this.GetComponent<PlayerVariableManager>().holdTimer = 0f;
            //this.GetComponent<PlayerVariableManager>().isSkillLockedIn = false;


            //! Perfect Timing
            /*if (this.GetComponent<PlayerLockInSkill>().isPerfectTiming == true)
            {
                actionTimerBarScript.startSelection = 20;
                this.GetComponent<PlayerLockInSkill>().isPerfectTiming = false;
            }
            else
            {
                actionTimerBarScript.startSelection = 0;
            }*/
            //this.GetComponent<actionTimeBar>().isBarFull = false;
            //this.GetComponent<PlayerLockInSkill>().lockedInTimer = 0;
            //this.GetComponent<actionTimeBar>().fullTimer = 0;
            this.GetComponent<PlayerVariableManager>().isTargetLockedIn = false;
            this.GetComponent<PlayerVariableManager>().targetedEnemy = null;
            this.GetComponent<PlayerVariableManager>().targetedEnemy = null;
            this.GetComponent<actionTimeBar>().selectionBar.fillAmount = 0;
            this.GetComponent<actionTimeBar>().startSelection = 0;
            TriggerBurn();
            GetComponent<PlayerArtifactEffect>().ArtifactActionEffect();

            this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState = BattleStateManager.GAMESTATE.CHOOSING_SKILL;
        }
    }

    void ResetColor()
    {
        this.GetComponent<PlayerVariableManager>().targetedEnemy.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }

    void ResetMovement()
    {
        this.transform.GetChild(0).GetComponent<Transform>().Translate(-1,0,0);
    }

    void ResetAnimation()
    {
        this.GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<PlayerVariableManager>().idleAnimation);
    }

    void TriggerBurn()
    {
        statusList = GetComponent<PlayerVariableManager>().statusList;
        if(statusList.Count>0)
        {
            for (int i = statusList.Count-1; i >= 0; i--)
            {
                if (statusList[i].GetComponent<StatusDetail>() is Burn)
                {
                    statusList[i].GetComponent<StatusDetail>().effect = false;
                    break;
                }
            }
        }
    }
}

