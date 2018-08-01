using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    CampsiteManager csm;
    CampsiteSelection css;

    public CampsiteUIComponent player1;
    public CampsiteUIComponent player2;
    public Text text;
    public Text instruction;

    void Start()
    {
        css = GetComponent<CampsiteSelection>();
        csm = GetComponent<CampsiteManager>();
        player1.state = CAMPSITE_STATE.SELECTION;
        player2.state = CAMPSITE_STATE.SELECTION;
    }

    void Update()
    {
        if (css.player1.upgraded == true)   text.color = Color.grey;
        else text.color = Color.white;
        if (css.player2.upgraded == true) text.color = Color.grey;
        else text.color = Color.white;

        if (player1.state == CAMPSITE_STATE.SELECTION)
        {
            instruction.text = "Hold \"A\" and \"L\" to Select";
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
            instruction.text = "Press \"A\" and \"L\" to Swap Pages, Hold to Back";
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
            instruction.text = "Press \"A\" and \"L\" to Scroll, Hold to Confirm";
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
        csm.playerList[0].SetActive(true);
        csm.playerList[1].SetActive(true);

        //! RE active the skill and canvas 
        for (int i = 0; i < csm.playerList.Count; i++)
        {
            csm.playerList[i].GetComponent<actionTimeBar>().enabled = true;
            for (int j = 1; j < csm.playerList[i].transform.childCount; j++)
            {
                csm.playerList[i].transform.GetChild(j).gameObject.SetActive(true);
            }
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
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
