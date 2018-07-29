using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusUpdate : PlayerVariableManager {
    public bool haste = false;
    public bool slow = false;
    private void Update()
    {
        statusList = GetComponent<PlayerVariableManager>().statusList;
        
        if (statusList.Count > 0)
        {
            for (int i = statusList.Count - 1; i > 0; i--)
            {
                for (int j = i-1; j >= 0; j--)
                {
                    if (statusList[i].GetComponent<StatusDetail>().ID ==  statusList[j].GetComponent<StatusDetail>().ID)
                    {
                        Destroy(statusList[i].gameObject);
                        statusList.Remove(statusList[i]);
                    }
                }
            }
            for (int i = statusList.Count - 1; i >= 0; i--)
            {
                if(statusList[i].GetComponent<StatusDetail>() is Haste || statusList[i].GetComponent<StatusDetail>() is Slow)
                {
                    NeutralizeHasteAndSlow();
                }
                statusList[i].GetComponent<StatusDetail>().user = gameObject;
                statusList[i].GetComponent<StatusDetail>().userType = StatusDetail.UserType.PLAYER;
                statusList[i].GetComponent<StatusDetail>().DoEffect();
                if (!statusList[i].GetComponent<StatusDetail>().isActive)
                {
                    statusList[i].GetComponent<StatusDetail>().RemoveStatus();
                    Destroy(statusList[i].gameObject);
                    statusList.Remove(statusList[i]);    
                }
            }
        }
    }

    void NeutralizeHasteAndSlow()
    {
        for(int i = statusList.Count - 1; i >= 0; i--)
        {
            for(int j=statusList.Count-2;j>=0;j--)
            {
                if(statusList[i].GetComponent<StatusDetail>() is Haste && statusList[j].GetComponent<StatusDetail>() is Slow)
                {
                    statusList[i].GetComponent<StatusDetail>().user = gameObject;
                    statusList[i].GetComponent<StatusDetail>().userType = StatusDetail.UserType.PLAYER;
                    statusList[i].GetComponent<StatusDetail>().DoEffect();
                    statusList[i].GetComponent<StatusDetail>().secondDuration = 0;
                    statusList[j].GetComponent<StatusDetail>().user = gameObject;
                    statusList[j].GetComponent<StatusDetail>().userType = StatusDetail.UserType.PLAYER;
                    statusList[j].GetComponent<StatusDetail>().DoEffect();
                    statusList[j].GetComponent<StatusDetail>().secondDuration = 0;
                }
            }
        }
    }
}
