using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : StatusDetail
{
    float tick = 0;
    float tickMax = 1f;
    private void Awake()
    {
        isActive = true;
        secondDuration = 10;
        type = "Good";
        ID = 7;
    }

    public override void DoEffect()
    {
        if (secondDuration == 10)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<PlayerStatusList>().statusIcon.Add(this.icon);
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStatusList>().statusIcon.Add(this.icon);
            }
        }
        else if (secondDuration <= 0)
        {
            isActive = false;
        }

        if (isActive)
        {
            secondDuration -= Time.deltaTime;
            tick += Time.deltaTime;
        }
        if (tick >= tickMax)
        {
            if (userType == UserType.PLAYER)
            {
                float reg = user.GetComponent<PlayerStats>().baseHealth * 0.05f;
                user.GetComponent<PlayerStats>().health += (int)reg;
                tick = 0;
            }
            else if (userType == UserType.ENEMY)
            {
                float reg = user.GetComponent<EnemyStats>().baseHealth * 0.05f;
                user.GetComponent<EnemyStats>().health += (int)reg;
                tick = 0;
            }
            tick = 0;
        }
       
    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStatusList>().statusIcon.Remove(user.GetComponent<PlayerStatusList>().statusIcon.Find(x => x == this.icon));
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStatusList>().statusIcon.Remove(user.GetComponent<EnemyStatusList>().statusIcon.Find(x => x == this.icon));
        }
    }
}

