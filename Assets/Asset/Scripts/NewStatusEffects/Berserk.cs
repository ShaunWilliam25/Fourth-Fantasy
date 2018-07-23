using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserk : StatusDetail
{
    private void Awake()
    {
        isActive = true;
        secondDuration = 6;
        type = "Neutral";
        ID = 5;
    }

    public override void DoEffect()
    {
        if (secondDuration == 10)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<PlayerStats>().silence = true;
                user.GetComponent<PlayerStatusList>().statusIcon.Add(this.icon);
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().silence = true;
                user.GetComponent<EnemyStatusList>().statusIcon.Add(this.icon);
            }
        }
        else if (secondDuration <= 0)
        {
            isActive = false;
        }
        secondDuration-=Time.deltaTime;
    }

    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().silence = false;
            user.GetComponent<PlayerStatusList>().statusIcon.Remove(user.GetComponent<PlayerStatusList>().statusIcon.Find(x => x == this.icon));
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().silence = false;
            user.GetComponent<EnemyStatusList>().statusIcon.Remove(user.GetComponent<EnemyStatusList>().statusIcon.Find(x => x == this.icon));
        }
    }
}
