using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CampsiteSelection : MonoBehaviour
{
    ShowUI showUI;
    ShowSkill showSkill;
    CampsiteManager csm;
    public CampsiteMenu player1, player2;
    public List<Image> upgrade3 = new List<Image>(3);
    public float timeNeeded = 1;
    public float p1Hold, p2Hold;
    public int p1Highlight = 0, p2Highlight = 0;
    public GameObject upgradeObject;
    SkillUpgrade skillUpgrade;
    

    void Start()
    {
        skillUpgrade = this.GetComponent<SkillUpgrade>();
        showUI = GetComponent<ShowUI>();
        showSkill = GetComponent<ShowSkill>();
        csm = this.GetComponent<CampsiteManager>();
        //upgradeObject = new GameObject();
    }

    void Update()
    {
        Select();
        ChangePage();
        Back();
        Upgrade();

        if (Input.GetKey("a"))
        {
            p1Hold += Time.deltaTime;
            if (p1Hold > timeNeeded)
            {
                if (showUI.player1.state != CAMPSITE_STATE.READY)
                {
                    p1Hold = 0;
                    if (player1.status.GetComponent<Image>().color == Color.red)
                    {
                        showUI.player1.state = CAMPSITE_STATE.STATUS_CHECK;
                    }
                    else if (player1.upgrade.GetComponent<Image>().color == Color.red)
                    {
                        showUI.player1.state = CAMPSITE_STATE.SKILL_UPGRADE;
                    }
                    else if (player1.ready.GetComponent<Text>().color == Color.yellow)
                    {
                        player1.ready.GetComponent<Text>().color = Color.green;
                        showUI.player1.state = CAMPSITE_STATE.READY;
                    }
                }
                else if (this.GetComponent<ShowUI>().player1.state == CAMPSITE_STATE.READY)
                {
                    p1Hold = 0;
                    player1.ready.GetComponent<Text>().color = Color.yellow;
                    showUI.player1.state = CAMPSITE_STATE.SELECTION;
                }
            }
        }
        else
        {
            p1Hold = 0;
        }

        if (Input.GetKey("l"))
        {
            p2Hold += Time.deltaTime;
            if (p2Hold > timeNeeded)
            {
                if (showUI.player2.state != CAMPSITE_STATE.READY)
                {
                    p2Hold = 0;
                    if (player2.status.GetComponent<Image>().color == Color.blue)
                    {
                        showUI.player2.state = CAMPSITE_STATE.STATUS_CHECK;
                    }
                    else if (player2.upgrade.GetComponent<Image>().color == Color.blue)
                    {
                        showUI.player2.state = CAMPSITE_STATE.SKILL_UPGRADE;
                    }
                    else if (player2.ready.GetComponent<Text>().color == Color.yellow)
                    {
                        player2.ready.GetComponent<Text>().color = Color.green;
                        showUI.player2.state = CAMPSITE_STATE.READY;
                    }
                }
                else if (this.GetComponent<ShowUI>().player2.state == CAMPSITE_STATE.READY)
                {
                    p2Hold = 0;
                    player2.ready.GetComponent<Text>().color = Color.yellow;
                    showUI.player2.state = CAMPSITE_STATE.SELECTION;
                }
            }
        }
        else
        {
            p2Hold = 0;
        }
    }

    private void Select()
    {
        if (showUI.player1.state == CAMPSITE_STATE.SELECTION)
        {
            if (Input.GetKeyUp("a"))
            {
                if (player1.status.GetComponent<Image>().color == Color.red)
                {
                    player1.status.GetComponent<Image>().color = Color.white;
                    player1.upgrade.GetComponent<Image>().color = Color.red;
                }
                else if (player1.upgrade.GetComponent<Image>().color == Color.red)
                {
                    player1.upgrade.GetComponent<Image>().color = Color.white;
                    player1.ready.GetComponent<Text>().color = Color.yellow;
                }
                else if (player1.ready.GetComponent<Text>().color == Color.yellow)
                {
                    player1.status.GetComponent<Image>().color = Color.red;
                    player1.ready.color = Color.white;
                }
            }
        }

        if (showUI.player2.state == CAMPSITE_STATE.SELECTION)
        {
            if (Input.GetKeyUp("l"))
            {
                if (player2.status.GetComponent<Image>().color == Color.blue)
                {
                    player2.status.GetComponent<Image>().color = Color.white;
                    player2.upgrade.GetComponent<Image>().color = Color.blue;
                }
                else if (player2.upgrade.GetComponent<Image>().color == Color.blue)
                {
                    player2.upgrade.GetComponent<Image>().color = Color.white;
                    player2.ready.GetComponent<Text>().color = Color.yellow;
                }
                else if (player2.ready.GetComponent<Text>().color == Color.yellow)
                {
                    player2.status.GetComponent<Image>().color = Color.blue;
                    player2.ready.color = Color.white;
                }
            }
        }
    }

    public void ChangePage()
    {
        if (showUI.player1.state == CAMPSITE_STATE.STATUS_CHECK)
        {
            if (Input.GetKeyUp("a"))
            {
                if (showUI.player1.page < 4)
                {
                    showUI.player1.page++;
                }
                else
                {
                    showUI.player1.page = 1;
                }
            }
        }

        if (showUI.player2.state == CAMPSITE_STATE.STATUS_CHECK)
        {
            if (Input.GetKeyUp("l"))
            {
                if (showUI.player2.page < 4)
                {
                    showUI.player2.page++;
                }
                else
                {
                    showUI.player2.page = 1;
                }
            }
        }
    }

    void Back()
    {
        if (showUI.player1.state == CAMPSITE_STATE.STATUS_CHECK /*|| showUI.player1.state == CAMPSITE_STATE.READY*/)
        {
            if (Input.GetKey("a"))
            {
                p1Hold += Time.deltaTime;
                if (p1Hold > timeNeeded)
                {
                    if (showUI.player1.state == CAMPSITE_STATE.STATUS_CHECK)
                    {
                        showUI.player1.state = CAMPSITE_STATE.SELECTION;
                    }
                    /*else if (showUI.player1.state == CAMPSITE_STATE.SKILL_UPGRADE)
                    {
                        showUI.player1.state = CAMPSITE_STATE.SELECTION;
                    }
                    else if (showUI.player1.state == CAMPSITE_STATE.READY)
                    {
                        showUI.player1.state = CAMPSITE_STATE.SELECTION;
                    }*/
                    p1Hold = 0;
                }
            }
            else
            {
                p1Hold = 0;
            }
        }

        if (showUI.player2.state == CAMPSITE_STATE.STATUS_CHECK /*|| showUI.player2.state == CAMPSITE_STATE.READY*/)
        {
            if (Input.GetKey("l"))
            {
                p2Hold += Time.deltaTime;
                if (p2Hold > timeNeeded)
                {
                    if (showUI.player2.state == CAMPSITE_STATE.STATUS_CHECK)
                    {
                        showUI.player2.state = CAMPSITE_STATE.SELECTION;
                    }
                    /*else if (showUI.player2.state == CAMPSITE_STATE.SKILL_UPGRADE)
                    {
                        showUI.player2.state = CAMPSITE_STATE.SELECTION;
                    }
                    else if (showUI.player2.state == CAMPSITE_STATE.READY)
                    {
                        showUI.player2.state = CAMPSITE_STATE.SELECTION;
                    }*/
                    p2Hold = 0;
                }
            }
            else
            {
                p2Hold = 0;
            }
        }
    }

    void Upgrade()
    {
        if (showUI.player1.state == CAMPSITE_STATE.SKILL_UPGRADE)
        {
            if (player1.upgradeState == UPGRADE_STATE.CHOOSE_SKILL)
            {
                showUI.player1.popUp.SetActive(true);
                if (Input.GetKeyUp("a"))
                {
                    if (p1Highlight < 4)
                    {
                        p1Highlight++;
                    }
                    else
                    {
                        p1Highlight = 0;
                    }
                    player1.highlighted.transform.localPosition = showSkill.player[0].skillImage[p1Highlight].transform.localPosition;
                    showUI.player1.popUp.transform.localPosition = new Vector3(showSkill.player[0].skillImage[p1Highlight].transform.localPosition.x + 150, showSkill.player[0].skillImage[p1Highlight].transform.localPosition.y + 110, showSkill.player[0].skillImage[p1Highlight].transform.localPosition.z);
                    player1.detail.GetComponent<Text>().text = csm.playerList[0].GetComponent<PlayerVariableManager>().skillList[p1Highlight].GetComponent<SkillDetail>().skillDescription;
                }

                if (Input.GetKey("a"))
                {
                    p1Hold += Time.deltaTime;
                    if (p1Hold >= timeNeeded)
                    {
                        p1Hold = 0;
                        player1.selectedSkill.GetComponent<Image>().sprite = showSkill.player[0].skillImage[p1Highlight].sprite;
                        player1.skillIndex = p1Highlight;
                        player1.upgradeState = UPGRADE_STATE.CHOOSE_UPGRADE;
                    }
                }
                else
                {
                    p1Hold = 0;
                }
            }
            else if (player1.upgradeState == UPGRADE_STATE.CHOOSE_UPGRADE)
            {
                if (Input.GetKeyUp("a"))
                {
                    if (p1Highlight < 2)
                    {
                        p1Highlight++;
                    }
                    else
                    {
                        p1Highlight = 0;
                    }
                    player1.highlighted.transform.localPosition = upgrade3[p1Highlight].transform.localPosition;
                    showUI.player1.popUp.transform.localPosition = new Vector3(upgrade3[p1Highlight].transform.localPosition.x + 150, upgrade3[p1Highlight].transform.localPosition.y - 110, showSkill.player[0].skillImage[p1Highlight].transform.localPosition.z);
                }

                if (Input.GetKey("a"))
                {
                    p1Hold += Time.deltaTime;
                    if (p1Hold >= timeNeeded)
                    {
                        p1Hold = 0;
                        player1.selectedUpgrade.GetComponent<Image>().sprite = upgrade3[p1Highlight].sprite;
                        player1.upgradeIndex = p1Highlight;
                        switch (player1.upgradeIndex)
                        {
                            case 0:
                                upgradeObject = skillUpgrade.randomAttack();
                                break;
                            case 1:
                                upgradeObject = skillUpgrade.randomHeal();
                                break;
                            case 2:
                                upgradeObject = skillUpgrade.randomSupport();
                                break;
                        }
                        player1.upgradeState = UPGRADE_STATE.VALIDATE_UPGRADE;
                    }
                }
                else
                {
                    p1Hold = 0;
                }
            }
            else if (player1.upgradeState == UPGRADE_STATE.VALIDATE_UPGRADE)
            {
                showUI.player1.popUp.SetActive(false);
                GameObject upgradeSkillObject = Instantiate(upgradeObject);
                upgradeSkillObject.transform.parent = csm.playerList[0].transform.GetChild(1);
                csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[player1.skillIndex].GetComponent<SkillDetail>().skillExecutionHolder.Add(upgradeSkillObject);
                player1.upgraded = true;
                showUI.player1.state = CAMPSITE_STATE.SELECTION;
            }

        }
        else if (showUI.player2.state == CAMPSITE_STATE.SKILL_UPGRADE)
        {
            if (player2.upgradeState == UPGRADE_STATE.CHOOSE_SKILL)
            {
                showUI.player2.popUp.SetActive(true);
                if (Input.GetKeyUp("l"))
                {
                    if (p2Highlight < 4)
                    {
                        p2Highlight++;
                    }
                    else
                    {
                        p2Highlight = 0;
                    }
                    player2.highlighted.transform.localPosition = showSkill.player[1].skillImage[p2Highlight].transform.localPosition;
                    showUI.player2.popUp.transform.localPosition = new Vector3(showSkill.player[1].skillImage[p2Highlight].transform.localPosition.x + 150, showSkill.player[1].skillImage[p2Highlight].transform.localPosition.y + 110, showSkill.player[1].skillImage[p2Highlight].transform.localPosition.z);
                    player2.detail.GetComponent<Text>().text = csm.playerList[1].GetComponent<PlayerVariableManager>().skillList[p2Highlight].GetComponent<SkillDetail>().skillDescription;
                }

                if (Input.GetKey("l"))
                {
                    p2Hold += Time.deltaTime;
                    if (p2Hold >= timeNeeded)
                    {
                        p2Hold = 0;
                        player2.selectedSkill.GetComponent<Image>().sprite = showSkill.player[1].skillImage[p2Highlight].sprite;
                        player2.skillIndex = p2Highlight;
                        player2.upgradeState = UPGRADE_STATE.CHOOSE_UPGRADE;
                    }
                }
                else
                {
                    p2Hold = 0;
                }
            }
            else if (player2.upgradeState == UPGRADE_STATE.CHOOSE_UPGRADE)
            {
                if (Input.GetKeyUp("l"))
                {
                    if (p2Highlight < 2)
                    {
                        p2Highlight++;
                    }
                    else
                    {
                        p2Highlight = 0;
                    }
                    player2.highlighted.transform.localPosition = upgrade3[p2Highlight].transform.localPosition;
                    showUI.player2.popUp.transform.localPosition = new Vector3(upgrade3[p2Highlight].transform.localPosition.x + 150, upgrade3[p2Highlight].transform.localPosition.y - 110, showSkill.player[1].skillImage[p2Highlight].transform.localPosition.z);
                }

                if (Input.GetKey("l"))
                {
                    p2Hold += Time.deltaTime;
                    if (p2Hold >= timeNeeded)
                    {
                        p2Hold = 0;
                        player2.selectedUpgrade.GetComponent<Image>().sprite = upgrade3[p2Highlight].sprite;
                        player2.upgradeIndex = p1Highlight;
                        switch (player2.upgradeIndex)
                        {
                            case 0:
                                upgradeObject = skillUpgrade.randomAttack();
                                break;
                            case 1:
                                upgradeObject = skillUpgrade.randomHeal();
                                break;
                            case 2:
                                upgradeObject = skillUpgrade.randomSupport();
                                break;
                        }
                        player2.upgradeState = UPGRADE_STATE.VALIDATE_UPGRADE;
                    }
                }
                else
                {
                    p2Hold = 0;
                }
            }
            else if (player2.upgradeState == UPGRADE_STATE.VALIDATE_UPGRADE)
            {
                showUI.player2.popUp.SetActive(false);
                GameObject upgradeSkillObject = Instantiate(upgradeObject);
                upgradeSkillObject.transform.parent = csm.playerList[1].transform.GetChild(1);
                csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[player2.skillIndex].GetComponent<SkillDetail>().skillExecutionHolder.Add(upgradeSkillObject);
                player2.upgraded = true;
                showUI.player2.state = CAMPSITE_STATE.SELECTION;
            }

        }
    }
}

[Serializable]
public struct CampsiteMenu
{
    public Image status;
    public Image upgrade;
    public Image highlighted;
    public Image selectedSkill;
    public Image selectedUpgrade;
    public Text detail;
    public int skillIndex;
    public int upgradeIndex;
    public Text ready;
    public Text back;
    public bool upgraded;
    public UPGRADE_STATE upgradeState;
}

public enum UPGRADE_STATE
{
    CHOOSE_SKILL = 0,
    CHOOSE_UPGRADE,
    VALIDATE_UPGRADE,
    UPGRADE
}