using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusUpdate : EnemyVariableManager
{
    public bool haste = false;
    public bool slow = false;
    private void Update()
    {
        this.statusList = GetComponent<EnemyVariableManager>().statusList;

        if (this.statusList.Count > 0)
        {
            for (int i = this.statusList.Count - 1; i > 0; i--)
            {
                for (int j = i-1; j >= 0; j--)
                {
                    if (this.statusList[i].GetComponent<StatusDetail>().ID == this.statusList[j].GetComponent<StatusDetail>().ID)
                    {
                        Destroy(this.statusList[i].gameObject);
                        this.statusList.Remove(statusList[i]);
                    }
                }
            }
            for (int i = statusList.Count - 1; i >= 0; i--)
            {
                
                this.statusList[i].GetComponent<StatusDetail>().user = gameObject;
                this.statusList[i].GetComponent<StatusDetail>().userType = StatusDetail.UserType.ENEMY;
                this.statusList[i].GetComponent<StatusDetail>().DoEffect();
                if (statusList[i].GetComponent<StatusDetail>() is Haste || statusList[i].GetComponent<StatusDetail>() is Slow)
                {
                    NeutralizeHasteAndSlow();
                }
                if (!this.statusList[i].GetComponent<StatusDetail>().isActive)
                {
                    Debug.Log("Destroy" + statusList[i]);
                    this.statusList[i].GetComponent<StatusDetail>().RemoveStatus();
                    Destroy(statusList[i].gameObject);
                    this.statusList.Remove(statusList[i]);
                    
                }
            }
        }
    }

    void NeutralizeHasteAndSlow()
    {
        for (int i = statusList.Count - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (statusList[i].GetComponent<StatusDetail>() is Haste && statusList[j].GetComponent<StatusDetail>() is Slow)
                {
                    statusList[i].GetComponent<StatusDetail>().secondDuration = 0;
                    statusList[i].GetComponent<StatusDetail>().DoEffect();
                    statusList[j].GetComponent<StatusDetail>().secondDuration = 0;
                    statusList[j].GetComponent<StatusDetail>().DoEffect();
                }
                if (statusList[j].GetComponent<StatusDetail>() is Haste && statusList[i].GetComponent<StatusDetail>() is Slow)
                {
                    statusList[i].GetComponent<StatusDetail>().secondDuration = 0;
                    statusList[i].GetComponent<StatusDetail>().DoEffect();
                    statusList[j].GetComponent<StatusDetail>().secondDuration = 0;
                    statusList[j].GetComponent<StatusDetail>().DoEffect();
                }
            }
        }
    }
}
