using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillExecution : PlayerVariableManager
{
    PlayerStatusUpdate statusUpdateScript;
    public int isAttack = 0;
    public float attackAnimationTimer;
    public float spellAnimationTimer;
    [SerializeField] private PlayerScrollSkill scrollSkill;

    private void Awake()
    {

        actionTimerBarScript = this.GetComponent<actionTimeBar>();
        scrollSkill = this.GetComponent<PlayerScrollSkill>();
        //statusUpdateScript = GetComponent<PlayerStatusUpdate>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.EXECUTE_SKILL)
        {
            Debug.Log(this.GetComponent<PlayerVariableManager>().playerStats.name + "state is execute skill");
        }

        if (actionTimerBarScript.selectionBar.fillAmount >= 1)
        {
            if (this.GetComponent<PlayerVariableManager>().isTargetLockedIn)
            {
                this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState = BattleStateManager.GAMESTATE.EXECUTE_SKILL;
            }
        }
        if (this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.EXECUTE_SKILL)
        {
            for (int i = 0; i < this.GetComponent<PlayerVariableManager>().skillHolder[scrollSkill.skillSelected].GetComponent<SkillDetail>().skillExecutionHolder.Count; i++)
            {
                //! Execute skill
                //this.GetComponent<PlayerVariableManager>().lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[i].GetComponent<SkillEffect>().Execute(this.GetComponent<PlayerVariableManager>().targetedEnemy);
                if(this.GetComponent<PlayerVariableManager>().targetedEnemy.GetComponent<EnemyVariableManager>().enemyStats.health > 0)
                {
                    this.GetComponent<PlayerVariableManager>().skillHolder[scrollSkill.skillSelected].GetComponent<SkillDetail>().skillExecutionHolder[i].GetComponent<SkillEffect>().Execute(this.GetComponent<PlayerVariableManager>().targetedEnemy);
                    if(this.GetComponent<PlayerVariableManager>().skillHolder[scrollSkill.skillSelected].GetComponent<SkillDetail>().skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.OFFENSIVE)
                    {
                        this.GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<PlayerVariableManager>().attackAnimation);
                        Invoke("ResetAnimation", attackAnimationTimer);
                    }
                    else
                    {
                        this.GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<PlayerVariableManager>().spellAnimation);
                        Invoke("ResetAnimation", spellAnimationTimer);
                    }
                    
                    //! Update the battle log
                    this.GetComponent<PlayerVariableManager>().battleLogScript.AddEvent(this.GetComponent<PlayerVariableManager>().playerStats.name + " " + this.GetComponent<PlayerVariableManager>().skillHolder[scrollSkill.skillSelected].GetComponent<SkillDetail>().skillDescription);

                    //! Check for tutorial 2
                    isAttack++;                    

                    this.GetComponent<PlayerVariableManager>().oriColor = this.GetComponent<PlayerVariableManager>().targetedEnemy.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                    this.GetComponent<PlayerVariableManager>().targetedEnemy.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                    Invoke("ResetColor", 0.2f);
                    
                }
                

                /*//! Update the battle log
                this.GetComponent<PlayerVariableManager>().battleLogScript.AddEvent(this.GetComponent<PlayerVariableManager>().playerStats.name + " " + this.GetComponent<PlayerVariableManager>().skillHolder[scrollSkill.skillSelected].GetComponent<SkillDetail>().skillDescription);

                //! Check for tutorial 2
                isAttack++;
                /*if (this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count / 2].GetComponent<SkillDetail>().skillName == "Normal Attack")
                {
                    isAttack++;
                }

                this.GetComponent<PlayerVariableManager>().oriColor = this.GetComponent<PlayerVariableManager>().targetedEnemy.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                this.GetComponent<PlayerVariableManager>().targetedEnemy.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;                
                this.GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<PlayerVariableManager>().attackAnimation);
                Invoke("ResetColor", 0.2f);
                //Invoke("ResetMovement", 0.2f);
                Invoke("ResetAnimation", attackAnimationTimer);*/
            }

            //! Reducing action required to revive ally
            if(this.GetComponent<PlayerVariableManager>().allySpawnPoint.GetComponent<PlayerStats>().reviveAction > 0)
            {
                this.GetComponent<PlayerVariableManager>().allySpawnPoint.GetComponent<PlayerStats>().reviveAction--;
            }
            //this.GetComponent<actionTimeBar>().isBarFull = false;
            //this.GetComponent<PlayerLockInSkill>().lockedInTimer = 0;
            //this.GetComponent<actionTimeBar>().fullTimer = 0;
            this.GetComponent<PlayerVariableManager>().isTargetLockedIn = false;
            //this.GetComponent<PlayerVariableManager>().targetedEnemy = null;
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

