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
                for (int i = GetComponent<PlayerVariableManager>().statusList.Count-1; i>= 0 ; i--)
                {
                    if (GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>().type == "Bad")
                    {
                        GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>().RemoveStatus();
                        GetComponent<PlayerVariableManager>().statusList.Remove(GetComponent<PlayerVariableManager>().statusList[i]);
                    }
                }
            }
            else if (userType == UserType.ENEMY)
            {
                for (int i = GetComponent<EnemyVariableManager>().statusList.Count-1; i >= 0; i--)
                {
                    if (GetComponent<EnemyVariableManager>().statusList[i].GetComponent<StatusDetail>().type == "Bad")
                    {
                        GetComponent<EnemyVariableManager>().statusList[i].GetComponent<StatusDetail>().RemoveStatus();
                        GetComponent<EnemyVariableManager>().statusList.Remove(GetComponent<PlayerVariableManager>().statusList[i]);
                    }
                }
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
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStatusList>().statusIcon.Remove(user.GetComponent<EnemyStatusList>().statusIcon.Find(x => x == this.icon));
        }
        effect = false;
    }
}
