using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : StatusDetail
{

    private void Awake()
    {
        isActive = true;
        secondDuration = 10f;
        type = "Good";
        ID = 12;
    }

    public override void DoEffect()
    {
        if (secondDuration == 10)
        {

            user.GetComponent<PlayerStats>().taunt = true;
        }
        else if (secondDuration <= 0)
        {
            isActive = false;
        }
        secondDuration -= Time.deltaTime;
    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().silence = false;
        user.GetComponent<PlayerStatusList>().statusIcon.Remove(user.GetComponent<PlayerStatusList>().statusIcon.Find(x => x == this.icon));   
    }
}
