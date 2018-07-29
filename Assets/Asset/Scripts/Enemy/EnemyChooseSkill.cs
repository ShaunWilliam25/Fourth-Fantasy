using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChooseSkill : EnemyVariableManager {
    public TutorialAppear tutorial;
    public List<int> chance;
    public bool isFinalBoss;
    [SerializeField] private GameObject ultimate;
    // Use this for initialization
    void Start()
    {
        tutorial = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TutorialAppear>();
        //Set user of skill to enemy(Didn't use same code as player)
        
        for(int i=0;i<GetComponent<EnemyVariableManager>().skillList.Count;i++)
        {
            GetComponent<EnemyVariableManager>().skillList[i].GetComponent<SkillEffect>().user = this.gameObject;
        }

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

                this.GetComponent<EnemyVariableManager>().Target.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                Invoke("ResetColor", 0.2f);
                // Random Skill Choosing
                RandomSkill();
                AudioManager.instance.PlaySound("EnemyAttackSound");             
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

    public void RandomSkill()
    {
        skillList = GetComponent<EnemyVariableManager>().skillList;
        if (GetComponent<EnemyStats>().silence || GetComponent<EnemyStats>().berserk)
        {
            skillList[0].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
            return;
        }
        int rand = Random.Range(0, 101);
        if(isFinalBoss && (GetComponent<EnemyStats>().health/GetComponent<EnemyStats>().baseHealth)<=0.1)
        {
            ultimate.GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
            isFinalBoss = false;
            return;
        }
        switch(skillList.Count)
        {
            //enemy have 2 skills
            case 2:
                if(rand<=chance[0])
                {
                    skillList[0].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                else if(chance[0]<rand && rand<=(chance[0]+chance[1]))
                {
                    skillList[1].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                break;

            // enemy have 3 skills
            case 3:
                if (rand <= chance[0])
                {
                    skillList[0].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                else if (chance[0] < rand && rand <= (chance[0] + chance[1]))
                {
                    skillList[1].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                else if ((chance[0]+chance[1]) < rand && rand <= (chance[0] + chance[1] + chance[2]))
                {
                    skillList[2].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                break;

            //enemy have 4 skills
            case 4:
                if (rand <= chance[0])
                {
                    skillList[0].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                else if (chance[0] < rand && rand <= (chance[0] + chance[1]))
                {
                    skillList[1].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                else if ((chance[0] + chance[1]) < rand && rand <= (chance[0] + chance[1] + chance[2]))
                {
                    skillList[2].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                else if ((chance[0] + chance[1] + chance[2]) < rand && rand <= (chance[0] + chance[1] + chance[2] + chance[3]))
                {
                    skillList[3].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                break;

            case 5:
                if (rand <= chance[0])
                {
                    skillList[0].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                else if (chance[0] < rand && rand <= (chance[0] + chance[1]))
                {
                    skillList[1].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                else if ((chance[0] + chance[1]) < rand && rand <= (chance[0] + chance[1] + chance[2]))
                {
                    skillList[2].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                else if ((chance[0] + chance[1] + chance[2]) < rand && rand <= (chance[0] + chance[1] + chance[2] + chance[3]))
                {
                    skillList[3].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                else if ((chance[0] + chance[1] + chance[2] + chance[3]) < rand && rand <= (chance[0] + chance[1] + chance[2] + chance[3] + chance[4]))
                {
                    skillList[4].GetComponent<SkillEffect>().Execute(this.GetComponent<EnemyVariableManager>().Target);
                }
                break;
        }
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
    }
}
