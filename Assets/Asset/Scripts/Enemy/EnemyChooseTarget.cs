using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChooseTarget : EnemyVariableManager {

    private void Awake()
    {            
    }

    void Start()
    {
    }

    void Update()
    {
        /*if (!isTargetChosen && this.GetComponent<EnemyActionTimeBar>().ATBFull)
        {
            randNum = Random.Range(1, 101);
            if (playerList[0].GetComponent<PlayerStats>().aggro > playerList[1].GetComponent<PlayerStats>().aggro)
            {
                hiAggroTarget = playerList[0];
                loAggroTarget = playerList[1];
            }
            else if (playerList[1].GetComponent<PlayerStats>().aggro > playerList[0].GetComponent<PlayerStats>().aggro)
            {
                hiAggroTarget = playerList[1];
                loAggroTarget = playerList[0];
            }
            else if (playerList[0].GetComponent<PlayerStats>().aggro == playerList[1].GetComponent<PlayerStats>().aggro)
            {
                if(randNum <= 50)
                {
                    hiAggroTarget = playerList[0];
                    loAggroTarget = playerList[1];
                }
                if (randNum >= 51)
                {
                    hiAggroTarget = playerList[1];
                    loAggroTarget = playerList[0];
                }
            }
            isTargetChosen = true;
        }
        else
        {
            if (isSkillUsed)
            {
                isTargetChosen = false;
                isSkillUsed = false;
                this.GetComponent<EnemyActionTimeBar>().ATBFull = false;
            }
        }*/

        if (!this.GetComponent<EnemyVariableManager>().isTargetChosen)
        {
            

            //Debug.Log(isTargetChosen);
            if (this.GetComponent<EnemyVariableManager>().playerList[0].GetComponent<PlayerStats>().aggro > this.GetComponent<EnemyVariableManager>().playerList[1].GetComponent<PlayerStats>().aggro)
            {
                this.GetComponent<EnemyVariableManager>().hiAggroTarget = this.GetComponent<EnemyVariableManager>().playerList[0];
                this.GetComponent<EnemyVariableManager>().loAggroTarget = this.GetComponent<EnemyVariableManager>().playerList[1];
            }
            else if (this.GetComponent<EnemyVariableManager>().playerList[1].GetComponent<PlayerStats>().aggro > this.GetComponent<EnemyVariableManager>().playerList[0].GetComponent<PlayerStats>().aggro)
            {
                this.GetComponent<EnemyVariableManager>().hiAggroTarget = this.GetComponent<EnemyVariableManager>().playerList[1];
                this.GetComponent<EnemyVariableManager>().loAggroTarget = this.GetComponent<EnemyVariableManager>().playerList[0];
            }
            else
            {
                /*if (randNum <= 50)
                {
                    hiAggroTarget = playerList[0];
                    loAggroTarget = playerList[1];
                }
                if (randNum >= 51)
                {
                    hiAggroTarget = playerList[1];
                    loAggroTarget = playerList[0];
                }*/
                this.GetComponent<EnemyVariableManager>().hiAggroTarget = this.GetComponent<EnemyVariableManager>().playerList[0];
                this.GetComponent<EnemyVariableManager>().loAggroTarget = this.GetComponent<EnemyVariableManager>().playerList[1];
            }
            this.GetComponent<EnemyVariableManager>().randNum = Random.Range(1, 101);
        }
        else
        {
            
        }
        
        if (this.GetComponent<EnemyVariableManager>().randNum <= 50)
        {
            this.GetComponent<EnemyVariableManager>().Target = this.GetComponent<EnemyVariableManager>().hiAggroTarget;
            if (this.GetComponent<EnemyVariableManager>().Target.GetComponent<PlayerVariableManager>().playerStats.health <= 0)
            {
                this.GetComponent<EnemyVariableManager>().Target = this.GetComponent<EnemyVariableManager>().loAggroTarget;
            }
        }
        else
        {
            this.GetComponent<EnemyVariableManager>().Target = this.GetComponent<EnemyVariableManager>().loAggroTarget;
            if (this.GetComponent<EnemyVariableManager>().Target.GetComponent<PlayerVariableManager>().playerStats.health <= 0)
            {
                this.GetComponent<EnemyVariableManager>().Target = this.GetComponent<EnemyVariableManager>().hiAggroTarget;
            }
        }
        if(this.GetComponent<EnemyVariableManager>().Target.GetComponent<PlayerVariableManager>().playerStats.health <= 0)
        {
            this.GetComponent<EnemyVariableManager>().Target = this.GetComponent<EnemyVariableManager>().loAggroTarget;
        }
        this.GetComponent<EnemyVariableManager>().isTargetChosen = true;
        if (this.GetComponent<EnemyVariableManager>().isSkillUsed)
        {
            
            this.GetComponent<EnemyVariableManager>().isSkillUsed = false;
            this.GetComponent<EnemyVariableManager>().isTargetChosen = false;            
            this.GetComponent<EnemyActionTimeBar>().ATBFull = false;
            this.GetComponent<EnemyVariableManager>().curCooldown = 0;
            Debug.Log("Turning off");

        }
        //this.GetComponent<EnemyVariableManager>().aimIcon.SetActive(true);
        this.GetComponent<EnemyVariableManager>().aimIconPosition = this.GetComponent<EnemyVariableManager>().Target.transform.position;
        this.GetComponent<EnemyVariableManager>().aimIcon.transform.position = this.GetComponent<EnemyVariableManager>().aimIconPosition;
    }
}
