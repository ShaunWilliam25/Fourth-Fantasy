using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : StatusDetail
{
    public int burnDamage;
 
    private void Awake()
    {
        effect = false;
        isActive = true;
        secondDuration = 10;
        type = "Bad";
        ID = 3;
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
        if(effect == true)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<PlayerStats>().health -= burnDamage;
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().health -= burnDamage;
            }
            effect = false;
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
    }
}
