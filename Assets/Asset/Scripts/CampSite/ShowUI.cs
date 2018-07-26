using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public CampsiteUIComponent player1;
    public CampsiteUIComponent player2;
    public CampsiteSelection css;
    public Text text;

    void Start()
    {
        player1.state = CAMPSITE_STATE.SELECTION;
        player1.state = CAMPSITE_STATE.SELECTION;
        css = this.GetComponent<CampsiteSelection>();
    }

    void Update()
    {
        if (css.player1.upgraded == true)
        {
            text.color = Color.grey;
        }
        else
        {
            text.color = Color.white;
        }

        if (player1.state == CAMPSITE_STATE.SELECTION)
        {
            player1.select.SetActive(true);
            player1.checkPg1.SetActive(false);
            player1.checkPg2.SetActive(false);
            player1.checkPg3.SetActive(false);
            player1.checkPg4.SetActive(false);
            player1.upgrade.SetActive(false);
            player1.back.SetActive(false);
        }
        else if(player1.state == CAMPSITE_STATE.STATUS_CHECK)
        {
            player1.select.SetActive(false);
            player1.checkPg1.SetActive(false);
            player1.back.SetActive(true);
            if(player1.page == 1)
            {
                player1.checkPg1.SetActive(true);
                player1.checkPg2.SetActive(false);
                player1.checkPg3.SetActive(false);
                player1.checkPg4.SetActive(false);
            }
            else if(player1.page == 2)
            {
                player1.checkPg1.SetActive(false);
                player1.checkPg2.SetActive(true);
                player1.checkPg3.SetActive(false);
                player1.checkPg4.SetActive(false);
            }
            else if (player1.page == 3)
            {
                player1.checkPg1.SetActive(false);
                player1.checkPg2.SetActive(false);
                player1.checkPg3.SetActive(true);
                player1.checkPg4.SetActive(false);
            }
            else if (player1.page == 4)
            {
                player1.checkPg1.SetActive(false);
                player1.checkPg2.SetActive(false);
                player1.checkPg3.SetActive(false);
                player1.checkPg4.SetActive(true);
            }
        }
        else if (player1.state == CAMPSITE_STATE.SKILL_UPGRADE)
        {
            player1.select.SetActive(false);
            player1.checkPg1.SetActive(false);
            player1.checkPg2.SetActive(false);
            player1.checkPg3.SetActive(false);
            player1.checkPg4.SetActive(false);
            player1.upgrade.SetActive(true);
            player1.back.SetActive(false);
        }

        if (player2.state == CAMPSITE_STATE.SELECTION)
        {
            player2.select.SetActive(true);
            player2.checkPg1.SetActive(false);
            player2.checkPg2.SetActive(false);
            player2.checkPg3.SetActive(false);
            player2.checkPg4.SetActive(false);
            player2.upgrade.SetActive(false);
            player2.back.SetActive(false);
        }
        else if (player2.state == CAMPSITE_STATE.STATUS_CHECK)
        {
            player2.select.SetActive(false);
            player2.checkPg1.SetActive(false);
            player2.back.SetActive(true);
            if (player2.page == 1)
            {
                player2.checkPg1.SetActive(true);
                player2.checkPg2.SetActive(false);
                player2.checkPg3.SetActive(false);
                player2.checkPg4.SetActive(false);
            }
            else if (player2.page == 2)
            {
                player2.checkPg1.SetActive(false);
                player2.checkPg2.SetActive(true);
                player2.checkPg3.SetActive(false);
                player2.checkPg4.SetActive(false);
            }
            else if (player2.page == 3)
            {
                player2.checkPg1.SetActive(false);
                player2.checkPg2.SetActive(false);
                player2.checkPg3.SetActive(true);
                player2.checkPg4.SetActive(false);
            }
            else if (player2.page == 4)
            {
                player2.checkPg1.SetActive(false);
                player2.checkPg2.SetActive(false);
                player2.checkPg3.SetActive(false);
                player2.checkPg4.SetActive(true);
            }
        }
        else if (player2.state == CAMPSITE_STATE.SKILL_UPGRADE)
        {
            player2.select.SetActive(false);
            player2.checkPg1.SetActive(false);
            player2.checkPg2.SetActive(false);
            player2.checkPg3.SetActive(false);
            player2.checkPg4.SetActive(false);
            player2.upgrade.SetActive(true);
            player2.back.SetActive(false);
        }

        if (player1.state == CAMPSITE_STATE.READY && player2.state == CAMPSITE_STATE.READY)
        {
            Load();
        }
    }

    void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
}

[Serializable]
public struct CampsiteUIComponent
{
    public GameObject select;
    public GameObject upgrade;
    public GameObject back;
    public GameObject checkPg1;
    public GameObject checkPg2;
    public GameObject checkPg3;
    public GameObject checkPg4;
    public GameObject popUp;
    public int page;
    
    public CAMPSITE_STATE state;
}

public enum CAMPSITE_STATE
{
    SELECTION = 0,
    STATUS_CHECK,
    SKILL_UPGRADE,
    READY
}
