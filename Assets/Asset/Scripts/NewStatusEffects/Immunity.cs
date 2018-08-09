using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immunity : StatusDetail
{

    private void Awake()
    {
        isActive = true;
        secondDuration = 5;
        type = "Good";
        ID = 8;
    }

    public override void DoEffect()
    {
        if (secondDuration == 5)
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
        if (!effect)
        {
            if (userType == UserType.PLAYER)
            {
                for (int i = user.GetComponent<PlayerVariableManager>().statusList.Count-1; i>= 0 ; i--)
                {
                    if (user.GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>().type == "Bad")
                    {
                        user.GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>().secondDuration = 0;
                    }
                }
                user.GetComponent<PlayerStats>().immune = true;
            }
            else if (userType == UserType.ENEMY)
            {
                for (int i = user.GetComponent<EnemyVariableManager>().statusList.Count-1; i >= 0; i--)
                {
                    if (user.GetComponent<EnemyVariableManager>().statusList[i].GetComponent<StatusDetail>().type == "Bad")
                    {
                        user.GetComponent<EnemyVariableManager>().statusList[i].GetComponent<StatusDetail>().secondDuration = 0;
                    }
                }
                user.GetComponent<EnemyStats>().immune = true;
            }
           
            effect = true;
        }
        secondDuration -= Time.deltaTime;

    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStatusList>().statusIcon.Remove(user.GetComponent<PlayerStatusList>().statusIcon.Find(x => x == this.icon));
            user.GetComponent<PlayerStats>().immune = false;
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStatusList>().statusIcon.Remove(user.GetComponent<EnemyStatusList>().statusIcon.Find(x => x == this.icon));
            user.GetComponent<EnemyStats>().immune = false;
        }

        effect = false;
    }
}
