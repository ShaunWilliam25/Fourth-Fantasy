using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillChooseTarget : PlayerVariableManager
{
    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*SkillDetail sDetail = this.GetComponent<Character_Skill_List>().skillHolder[2].GetComponent<SkillDetail>();
        
        //! Checking if the state of the player is choosing target
        if (battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.CHOOSING_TARGET)
        {
            //! for each skill effect in the skill execution holder
            targetCursor.SetActive(true);
            targetCursorBar.SetActive(true);

            if (sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.OFFENSIVE)
            {
                targetCursor.transform.position = new Vector2(enemyTargetCursorPoints[cursorIndex].position.x, enemyTargetCursorPoints[cursorIndex].position.y + 2);
                targetCursorBar.transform.position = new Vector2(enemyTargetCursorPoints[cursorIndex].position.x, enemyTargetCursorPoints[cursorIndex].position.y + 2);
            }
            else if (sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.HEAL || sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.SUPPORTIVE)
            {
                targetCursor.transform.position = new Vector2(playerTargetCursorPoints[cursorIndex].position.x, playerTargetCursorPoints[cursorIndex].position.y + 2);
                targetCursorBar.transform.position = new Vector2(playerTargetCursorPoints[cursorIndex].position.x, playerTargetCursorPoints[cursorIndex].position.y + 2);
            }
            if (sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().numOfTarget == 1)
            {
                if (sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.OFFENSIVE)
                {
                    ScrollTarget(1);
                    ConfirmTarget(1);
                }
                else if (sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.HEAL || sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.SUPPORTIVE)
                {
                    ScrollTarget(2);
                    ConfirmTarget(2);
                }
            }
            //isTargetLockedIn = true;
            if (isTargetLockedIn)
            {
                holdTimer = 0f;
                targetCursor.SetActive(false);
                targetCursorBar.SetActive(false);
            }

        }*/

        //! Need to if its AOE
        if(!this.GetComponent<PlayerVariableManager>().isTargetLockedIn)
        {
            for (int i = 0; i < this.GetComponent<PlayerVariableManager>().enemySpawnScript.enemySpawnPoints.Count; i++)
            {
                if (this.GetComponent<PlayerVariableManager>().enemySpawnScript.enemySpawnPoints[i].transform.childCount != 0)
                {
                    if(this.GetComponent<PlayerVariableManager>().enemySpawnScript.enemySpawnPoints[i].GetChild(0).GetComponent<EnemyVariableManager>().enemyStats.health > 0)
                    {
                        this.GetComponent<PlayerVariableManager>().targetedEnemy = this.GetComponent<PlayerVariableManager>().enemySpawnScript.enemySpawnPoints[i].GetChild(0).gameObject;
                        break;
                    }                                            
                }
            }
            this.GetComponent<PlayerVariableManager>().isTargetLockedIn = true;
        }
        
        //! Checking it its empty
        if(!this.GetComponent<PlayerVariableManager>().isTargetLockedIn && this.GetComponent<PlayerVariableManager>().isTargetLockedIn == true)
        {
            this.GetComponent<PlayerVariableManager>().isTargetLockedIn = false;
        }
    }
}