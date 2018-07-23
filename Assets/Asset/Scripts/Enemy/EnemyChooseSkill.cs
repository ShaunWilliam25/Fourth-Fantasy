using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChooseSkill : EnemyVariableManager {
    public TutorialAppear tutorial;
    // Use this for initialization
    void Start()
    {
        tutorial = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TutorialAppear>();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (this.GetComponent<EnemyStats>().health <= this.GetComponent<EnemyStats>().baseHealth * 0.5f)
         {
             canUseUlti = true;
         }*/        

        if (this.GetComponent<EnemyVariableManager>().ATBFull)
        {
            if (this.GetComponent<EnemyVariableManager>().isTargetChosen)
            {
                this.GetComponent<EnemyVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<EnemyVariableManager>().attackAnimation);
                Invoke("ResetAnimation", 1.1f);

                Debug.Log("attack anim");

                this.GetComponent<EnemyVariableManager>().Target.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                Invoke("ResetColor", 0.2f);
                float tempDmg = this.GetComponent<EnemyVariableManager>().enemyStats.strength - (this.GetComponent<EnemyVariableManager>().Target.GetComponent<PlayerStats>().defense * 0.8f);
                this.GetComponent<EnemyVariableManager>().Target.GetComponent<PlayerStats>().health -= tempDmg;
                this.GetComponent<EnemyVariableManager>().audioManager.PlaySound("EnemyAttackSound");             
                this.GetComponent<EnemyVariableManager>().battlelogScript.AddEvent(this.name + " attacks " + this.GetComponent<EnemyVariableManager>().Target.name);
                // this.GetComponent<EnemyVariableManager>().isSkillUsed = false;
                //! Attack check for tutorial 6
                if (!tutorial.isEnemyAttacked)
                {
                    tutorial.isEnemyAttacked = true;
                }
                this.GetComponent<EnemyVariableManager>().isTargetChosen = false;
                this.GetComponent<EnemyVariableManager>().ATBFull = false;
                this.GetComponent<EnemyVariableManager>().curCooldown = 0;
                TriggerBurn();
                //this.GetComponent<EnemyVariableManager>().oriColor = this.GetComponent<EnemyVariableManager>().Target.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                
            }
        }
            
        /*{
            if (this.GetComponent<EnemyVariableManager>().ATBFull)
            {
                Debug.Log("use skill 1");
                float tempDmg = this.GetComponent<EnemyVariableManager>().enemyStats.strength - (this.GetComponent<EnemyVariableManager>().Target.GetComponent<PlayerStats>().defense * 0.8f);
                this.GetComponent<EnemyVariableManager>().Target.GetComponent<PlayerStats>().health -= tempDmg;
                this.GetComponent<EnemyVariableManager>().isSkillUsed = true;
                Debug.Log("USED SKILL");
            }

           /* if (!canUseUlti)
            {
                skillRandomizer();
            }
            else if(canUseUlti)
            {
                int randomNumber = Random.Range(0, 2);
                if(randomNumber == 0)
                {
                    if(UltiUsed)
                    {
                        skillRandomizer();
                    }
                    else 
                    {
                        Debug.Log("use skill 5");
                        float tempDmg = (this.GetComponent<EnemyStats>().magic * 3f) + (this.GetComponent<EnemyStats>().strength * 0.5f) - (this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().spirit * 1.3f);
                        this.GetComponent<EnemyStats>().health += tempDmg * 2;
                        this.GetComponent<EnemyChooseTarget>().hiAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
                        this.GetComponent<EnemyChooseTarget>().loAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
                        UltiUsed = true;
                    }
                }
                else
                {
                    skillRandomizer();
                }
            }
        }*/
    }

    void ResetColor()
    {
        this.GetComponent<EnemyVariableManager>().hiAggroTarget.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        this.GetComponent<EnemyVariableManager>().loAggroTarget.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void skillRandomizer()
    {
        randNo = Random.Range(1, 101);

        /*if (randNo <= 50)
        {
            Debug.Log("use skill 1");
            float tempDmg = this.GetComponent<EnemyStats>().strength - (this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().defense * 0.8f);
            this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().health -= tempDmg;
        }
        else if (randNo > 50 && randNo <= 80)
        {
            Debug.Log("use skill 2");
            float tempDmg = (this.GetComponent<EnemyStats>().strength * 1.5f) - (this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().defense * 0.7f);
            this.GetComponent<EnemyChooseTarget>().hiAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
            this.GetComponent<EnemyChooseTarget>().loAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
        }
        else if (randNo > 80 && randNo <= 90)
        {
            Debug.Log("use skill 3");
            float tempDmg = (this.GetComponent<EnemyStats>().magic * 0.7f) - (this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().spirit * 0.6f);
            this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().health -= tempDmg;
        }
        else if (randNo > 90 && randNo <= 100)
        {
            Debug.Log("use skill 4");
            float tempDmg = (this.GetComponent<EnemyStats>().magic * 2.5f) - (this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().spirit * 0.7f);
            this.GetComponent<EnemyChooseTarget>().hiAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
            this.GetComponent<EnemyChooseTarget>().loAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
        }*/

        this.GetComponent<EnemyChooseTarget>().isSkillUsed = true;
    }

    void TriggerBurn()
    {
        statusList = GetComponent<EnemyVariableManager>().statusList;
        if (statusList.Count > 0)
        {
            for (int i = statusList.Count - 1; i >= 0; i--)
            {
                if (statusList[i].GetComponent<StatusDetail>() is Burn)
                {
                    statusList[i].GetComponent<StatusDetail>().effect = true;
                    break;
                }
            }
        }
    }

    void ResetAnimation()
    {
        this.GetComponent<EnemyVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<EnemyVariableManager>().idleAnimation);
        Debug.Log("idle anim");
    }
}
