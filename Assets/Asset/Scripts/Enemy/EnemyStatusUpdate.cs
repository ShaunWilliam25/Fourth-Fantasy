﻿using System.Collections;
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
    
   /* void NeutralizeHasteAndSlow()
    {
        for (int i = this.statusList.Count - 1; i >= 0; i--)
        {
            for (int j = this.statusList.Count - 2; j >= 0; j--)
            {
                if (this.statusList[i].GetComponent<StatusDetail>() is Haste && this.statusList[j].GetComponent<StatusDetail>() is Slow)
                {
                    this.statusList[i].GetComponent<StatusDetail>().user = gameObject;
                    this.statusList[i].GetComponent<StatusDetail>().userType = StatusDetail.UserType.ENEMY;
                    this.statusList[i].GetComponent<StatusDetail>().DoEffect();
                    this.statusList[i].GetComponent<StatusDetail>().secondDuration = 0;
                    this.statusList[j].GetComponent<StatusDetail>().user = gameObject;
                    this.statusList[j].GetComponent<StatusDetail>().userType = StatusDetail.UserType.ENEMY;
                    this.statusList[j].GetComponent<StatusDetail>().DoEffect();
                    this.statusList[j].GetComponent<StatusDetail>().secondDuration = 0;
                }
            }
        }
    }*/
}
