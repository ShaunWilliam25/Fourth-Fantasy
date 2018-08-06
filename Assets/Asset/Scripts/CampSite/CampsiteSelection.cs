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
    SkillUpgrade skillUpgrade;
    public CampsiteMenu player1, player2;
    public List<Image> upgrade3 = new List<Image>(3);
    public float timeNeeded = 1;
    public float p1Hold, p2Hold;
    public int p1Highlight = 0, p2Highlight = 0;
    public GameObject upgradeObject1;
    public GameObject upgradeObject2;
    public ButtonStatus buttonStatus;
    private int maxUpgrade = 3;

    void Start()
    {
        skillUpgrade = GetComponent<SkillUpgrade>();
        showUI = GetComponent<ShowUI>();
        showSkill = GetComponent<ShowSkill>();
        csm = GetComponent<CampsiteManager>();
        player1.upgradeLeft = 1;
        player2.upgradeLeft = 1;
        /*for(int i = 0; i<csm.playerList.Count; i++)
        {
            //if (csm.playerList[i].GetComponent<PlayerVariableManager>().artifactsList.Exists(x => x.)
        }*/
    }

    void Update()
    {
        MenuSelect();
        ChangePage();
        BackAndUnready();
        Upgrade();

        if (showUI.player1.state == CAMPSITE_STATE.SELECTION)
        {
            if (Input.GetKey("a") && player1.upgradeLeft > 0)
            {
                p1Hold += Time.deltaTime;
                player1.fillFeedback.fillAmount = p1Hold;
                if (p1Hold > timeNeeded)
                {
                    p1Hold = 0;
                    if (player1.status.GetComponent<Image>().sprite == buttonStatus.chosen)
                    {
                        showUI.player1.state = CAMPSITE_STATE.STATUS_CHECK;
                    }
                    else if (player1.upgrade.GetComponent<Image>().sprite == buttonStatus.chosen)
                    {
                        showUI.player1.state = CAMPSITE_STATE.SKILL_UPGRADE;
                    }
                    else if (player1.ready.GetComponent<Image>().sprite == buttonStatus.chosen)
                    {
                        player1.readyText.GetComponent<Text>().color = Color.green;
                        player1.ready.GetComponent<Image>().sprite = buttonStatus.select;
                        showUI.player1.state = CAMPSITE_STATE.READY;
                        player1.fillFeedback.fillAmount = p1Hold;
                    }
                }
            }
            else if(Input.GetKey("a") && player1.upgradeLeft <= 0)
            {
                if (player1.status.GetComponent<Image>().sprite == buttonStatus.chosen)
                {
                    p1Hold += Time.deltaTime;
                    player1.fillFeedback.fillAmount = p1Hold;
                    if(p1Hold > timeNeeded)
                    {
                        p1Hold = 0;
                        showUI.player1.state = CAMPSITE_STATE.STATUS_CHECK;
                    }
                }
                else if (player1.ready.GetComponent<Image>().sprite == buttonStatus.chosen)
                {
                    p1Hold += Time.deltaTime;
                    player1.fillFeedback.fillAmount = p1Hold;
                    if (p1Hold > timeNeeded)
                    {
                        p1Hold = 0; 
                        player1.readyText.GetComponent<Text>().color = Color.green;
                        player1.ready.GetComponent<Image>().sprite = buttonStatus.select;
                        showUI.player1.state = CAMPSITE_STATE.READY;
                        player1.fillFeedback.fillAmount = p1Hold;
                    }
                }
            }
            else
            {
                p1Hold = 0;
                player1.fillFeedback.fillAmount = p1Hold;
            }         
        }

        if (showUI.player2.state == CAMPSITE_STATE.SELECTION)
        {
            if (Input.GetKey("l") && player2.upgradeLeft > 0)
            {
                p2Hold += Time.deltaTime;
                player2.fillFeedback.fillAmount = p2Hold;
                if (p2Hold > timeNeeded)
                {
                    p2Hold = 0;
                    if (player2.status.GetComponent<Image>().sprite == buttonStatus.chosen)
                    {
                        showUI.player2.state = CAMPSITE_STATE.STATUS_CHECK;
                    }
                    else if (player2.upgrade.GetComponent<Image>().sprite == buttonStatus.chosen && player2.upgradeLeft > 0)
                    {
                        showUI.player2.state = CAMPSITE_STATE.SKILL_UPGRADE;
                    }
                    else if (player2.ready.GetComponent<Image>().sprite == buttonStatus.chosen)
                    {
                        player2.readyText.GetComponent<Text>().color = Color.green;
                        player2.ready.GetComponent<Image>().sprite = buttonStatus.select;
                        showUI.player2.state = CAMPSITE_STATE.READY;
                        player2.fillFeedback.fillAmount = p2Hold;
                    }
                }
            }
            else if (Input.GetKey("l") && player2.upgradeLeft <= 0)
            {
                if (player2.status.GetComponent<Image>().sprite == buttonStatus.chosen)
                {
                    p2Hold += Time.deltaTime;
                    player2.fillFeedback.fillAmount = p2Hold;
                    if (p2Hold > timeNeeded)
                    {
                        p2Hold = 0;
                        showUI.player2.state = CAMPSITE_STATE.STATUS_CHECK;
                    }
                }
                else if (player2.ready.GetComponent<Image>().sprite == buttonStatus.chosen)
                {
                    p2Hold += Time.deltaTime;
                    player2.fillFeedback.fillAmount = p2Hold;
                    if (p2Hold > timeNeeded)
                    {
                        p2Hold = 0;
                        player2.readyText.GetComponent<Text>().color = Color.green;
                        player2.ready.GetComponent<Image>().sprite = buttonStatus.select;
                        showUI.player2.state = CAMPSITE_STATE.READY;
                        player2.fillFeedback.fillAmount = p2Hold;
                    }
                }
            }
            else
            {
                p2Hold = 0;
                player2.fillFeedback.fillAmount = p2Hold;
            }
        }
    }

    private void MenuSelect()
    {
        if (showUI.player1.state == CAMPSITE_STATE.SELECTION)
        {
            if (Input.GetKeyUp("a"))
            {
                if (player1.status.GetComponent<Image>().sprite == buttonStatus.chosen)
                {
                    player1.status.GetComponent<Image>().sprite = buttonStatus.normal;
                    player1.upgrade.GetComponent<Image>().sprite = buttonStatus.chosen;
                    player1.fillFeedback.transform.position = player1.upgrade.transform.position;
                }
                else if (player1.upgrade.GetComponent<Image>().sprite == buttonStatus.chosen)
                {
                    player1.upgrade.GetComponent<Image>().sprite = buttonStatus.normal;
                    player1.ready.GetComponent<Image>().sprite = buttonStatus.chosen;
                    player1.fillFeedback.transform.position = player1.ready.transform.position;
                }
                else if (player1.ready.GetComponent<Image>().sprite == buttonStatus.chosen)
                {
                    player1.ready.GetComponent<Image>().sprite = buttonStatus.normal;
                    player1.status.GetComponent<Image>().sprite = buttonStatus.chosen;
                    player1.fillFeedback.transform.position = player1.status.transform.position;
                }
            }
        }

        if (showUI.player2.state == CAMPSITE_STATE.SELECTION)
        {
            if (Input.GetKeyUp("l"))
            {
                if (player2.status.GetComponent<Image>().sprite == buttonStatus.chosen)
                {
                    player2.status.GetComponent<Image>().sprite = buttonStatus.normal;
                    player2.upgrade.GetComponent<Image>().sprite = buttonStatus.chosen;
                    player2.fillFeedback.transform.position = player2.upgrade.transform.position;
                }
                else if (player2.upgrade.GetComponent<Image>().sprite == buttonStatus.chosen)
                {
                    player2.upgrade.GetComponent<Image>().sprite = buttonStatus.normal;
                    player2.ready.GetComponent<Image>().sprite = buttonStatus.chosen;
                    player2.fillFeedback.transform.position = player2.ready.transform.position;
                }
                else if (player2.ready.GetComponent<Image>().sprite == buttonStatus.chosen)
                {
                    player2.ready.GetComponent<Image>().sprite = buttonStatus.normal;
                    player2.status.GetComponent<Image>().sprite = buttonStatus.chosen;
                    player2.fillFeedback.transform.position = player2.status.transform.position;
                }
            }
        }
    }

    private void ChangePage()
    {
        if (showUI.player1.state == CAMPSITE_STATE.STATUS_CHECK)
        {
            if (Input.GetKeyUp("a"))
            {
                showUI.player1.backFill.fillAmount = 0;
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
                showUI.player2.backFill.fillAmount = 0;
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

    private void BackAndUnready()
    {
        if (showUI.player1.state == CAMPSITE_STATE.STATUS_CHECK || showUI.player1.state == CAMPSITE_STATE.READY)
        {
            if (Input.GetKey("a"))
            {
                p1Hold += Time.deltaTime;
                player1.fillFeedback.fillAmount = p1Hold;
                showUI.player1.backFill.fillAmount = p1Hold;
                if (p1Hold > timeNeeded)
                {
                    if (showUI.player1.state == CAMPSITE_STATE.STATUS_CHECK)
                    {
                        showUI.player1.state = CAMPSITE_STATE.SELECTION;
                    }
                    else if (this.GetComponent<ShowUI>().player1.state == CAMPSITE_STATE.READY)
                    {
                        player1.readyText.GetComponent<Text>().color = Color.white;
                        player1.ready.GetComponent<Image>().sprite = buttonStatus.chosen;
                        showUI.player1.state = CAMPSITE_STATE.SELECTION;
                    }
                    p1Hold = 0;
                    player1.fillFeedback.fillAmount = p1Hold;
                    showUI.player1.backFill.fillAmount = p1Hold;
                }
            }
            else
            {
                p1Hold = 0;
                player1.fillFeedback.fillAmount = p1Hold;
            }
        }

        if (showUI.player2.state == CAMPSITE_STATE.STATUS_CHECK || showUI.player2.state == CAMPSITE_STATE.READY)
        {
            if (Input.GetKey("l"))
            {
                p2Hold += Time.deltaTime;
                player2.fillFeedback.fillAmount = p2Hold;
                showUI.player2.backFill.fillAmount = p2Hold;
                if (p2Hold > timeNeeded)
                {
                    if (showUI.player2.state == CAMPSITE_STATE.STATUS_CHECK)
                    {
                        showUI.player2.state = CAMPSITE_STATE.SELECTION;
                    }
                    else if (this.GetComponent<ShowUI>().player2.state == CAMPSITE_STATE.READY)
                    {
                        player2.ready.GetComponent<Image>().sprite = buttonStatus.chosen;
                        player2.readyText.GetComponent<Text>().color = Color.white;
                        showUI.player2.state = CAMPSITE_STATE.SELECTION;
                    }
                    p2Hold = 0;
                    player2.fillFeedback.fillAmount = p2Hold;
                    showUI.player2.backFill.fillAmount = p2Hold;
                }
            }
            else
            {
                p2Hold = 0;
                player2.fillFeedback.fillAmount = p2Hold;
            }
        }
    }

    void Upgrade()
    {
        if (showUI.player1.state == CAMPSITE_STATE.SKILL_UPGRADE)
        {
            if (player1.upgradeState == UPGRADE_STATE.CHOOSE_SKILL)
            {
                showUI.player1.popUp.SetActive(false);
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
                    player1.detail.text = csm.playerList[0].GetComponent<PlayerVariableManager>().skillList[p1Highlight].GetComponent<SkillDetail>().skillDescription;
                    //if upgraded, show the effect
                    if (csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[p1Highlight].GetComponent<SkillDetail>().upgradedCount > 0)
                    {
                        for(int i = 0; i < csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[p1Highlight].GetComponent<SkillDetail>().upgradedCount;i++)
                        {
                            player1.detail.GetComponent<Text>().text = player1.detail.GetComponent<Text>().text + "\r\n" + csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[p1Highlight].GetComponent<SkillDetail>().upgradedEffect[i];
                        }
                    }
                }

                if (Input.GetKey("a"))
                {
                    p1Hold += Time.deltaTime;
                    if (p1Hold >= timeNeeded)
                    {
                        p1Hold = 0;
                        if(csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[p1Highlight].GetComponent<SkillDetail>().upgradedCount < 3)
                        {
                            player1.selectedSkill.GetComponent<Image>().sprite = showSkill.player[0].skillImage[p1Highlight].sprite;
                            player1.skillIndex = p1Highlight;
                            player1.upgradeState = UPGRADE_STATE.CHOOSE_UPGRADE;
                        }
                        else
                        {
                            player1.detail.text = "This skill already max upgraded!";
                        }
                    }
                }
                else
                {
                    p1Hold = 0;
                }
            }
            else if (player1.upgradeState == UPGRADE_STATE.CHOOSE_UPGRADE)
            {
                showUI.player1.popUp.SetActive(true);
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

                    if(p1Highlight != 2)
                    {
                        showUI.player1.popUp.transform.localPosition = new Vector3(upgrade3[p1Highlight].transform.localPosition.x + 150, upgrade3[p1Highlight].transform.localPosition.y - 110, showSkill.player[0].skillImage[p1Highlight].transform.localPosition.z);
                    }
                    else
                    {
                        showUI.player1.popUp.transform.localPosition = new Vector3(upgrade3[p1Highlight].transform.localPosition.x - 150, upgrade3[p1Highlight].transform.localPosition.y - 110, showSkill.player[0].skillImage[p1Highlight].transform.localPosition.z);
                    }

                    switch (p1Highlight)
                    {
                        case 0:
                            showUI.player1.popUpText.text = "1. Deals 150 damage to single enemy (30%)\r\n2. Deals 100 damage to all enemies(30 %)\r\n3. Deals 90 damage to all enemies and causes poison(20 %)\r\n4. Deals 130 damage to single enemy and causes slow(20 %)";                            
                            break;
                        case 1:
                            showUI.player1.popUpText.text = "1. Heals 100 HP to self (50%)\r\n2. Heals 50 HP to all allies (40%)\r\n3.Heals 50 HP for each bad status effect on character (10%)";
                            break;
                        case 2:
                            showUI.player1.popUpText.text = "1. Dispels one bad status effect on self (35%)\r\n2. Dispels one good status effect on enemy(35%)\r\n3. 20 % chance adding bless to self(20%)\r\n4. Inflicts curse to enemy(10%)";
                            break;
                    }
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
                                upgradeObject1 = skillUpgrade.randomAttack();
                                break;
                            case 1:
                                upgradeObject1 = skillUpgrade.randomHeal();
                                break;
                            case 2:
                                upgradeObject1 = skillUpgrade.randomSupport();
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
                GameObject upgradeSkillObject = Instantiate(upgradeObject1);
                upgradeSkillObject.transform.parent = csm.playerList[0].transform.GetChild(1).GetChild(2+player1.skillIndex);
                upgradeSkillObject.GetComponent<SkillEffect>().user = csm.playerList[0];
                upgradeSkillObject.GetComponent<SkillEffect>().playerArtifact = csm.playerList[0].GetComponent<PlayerArtifactEffect>();
                csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[player1.skillIndex].GetComponent<SkillDetail>().skillExecutionHolder.Add(upgradeSkillObject);
                csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[player1.skillIndex].GetComponent<SkillDetail>().upgradedCount++;
                csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[player1.skillIndex].GetComponent<SkillDetail>().upgradedEffect.Add(upgradeSkillObject.GetComponent<UpgradeDescription>().upgradeDescription);
                player1.upgradeLeft--;
                player1.upgradeState = UPGRADE_STATE.UPGRADE;
            }
            else if(player1.upgradeState == UPGRADE_STATE.UPGRADE)
            {
                player1.detail.text = csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[player1.skillIndex].GetComponent<SkillDetail>().skillName + " upgraded with " + upgradeObject1.GetComponent<UpgradeDescription>().upgradeDescription + "\r\n \r\nPress any key to continue";
                if(Input.anyKeyDown)
                {
                    showUI.player1.state = CAMPSITE_STATE.SELECTION;
                }
            }
        }

        if (showUI.player2.state == CAMPSITE_STATE.SKILL_UPGRADE)
        {
            if (player2.upgradeState == UPGRADE_STATE.CHOOSE_SKILL)
            {
                showUI.player2.popUp.SetActive(false);
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
                    player2.detail.text = csm.playerList[1].GetComponent<PlayerVariableManager>().skillList[p2Highlight].GetComponent<SkillDetail>().skillDescription;
                    //if upgraded, show the effect
                    if (csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[p2Highlight].GetComponent<SkillDetail>().upgradedCount > 0)
                    {
                        for (int i = 0; i < csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[p2Highlight].GetComponent<SkillDetail>().upgradedCount; i++)
                        {
                            player2.detail.GetComponent<Text>().text = player2.detail.GetComponent<Text>().text + "\r\n" + csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[p2Highlight].GetComponent<SkillDetail>().upgradedEffect[i];
                        }
                    }
                }

                if (Input.GetKey("l"))
                {
                    p2Hold += Time.deltaTime;
                    if (p2Hold >= timeNeeded)
                    {
                        p2Hold = 0;
                        if (csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[p2Highlight].GetComponent<SkillDetail>().upgradedCount < 3)
                        {
                            player2.selectedSkill.GetComponent<Image>().sprite = showSkill.player[1].skillImage[p2Highlight].sprite;
                            player2.skillIndex = p2Highlight;
                            player2.upgradeState = UPGRADE_STATE.CHOOSE_UPGRADE;
                        }
                        else
                        {
                            player2.detail.text = "This skill already max upgraded!";
                        }
                    }
                }
                else
                {
                    p2Hold = 0;
                }
            }
            else if (player2.upgradeState == UPGRADE_STATE.CHOOSE_UPGRADE)
            {
                showUI.player2.popUp.SetActive(true);
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

                    if(p2Highlight != 0)
                    {
                        showUI.player2.popUp.transform.localPosition = new Vector3(upgrade3[p2Highlight].transform.localPosition.x - 150, upgrade3[p2Highlight].transform.localPosition.y - 110, showSkill.player[1].skillImage[p2Highlight].transform.localPosition.z);
                    }
                    else
                    {
                        showUI.player2.popUp.transform.localPosition = new Vector3(upgrade3[p2Highlight].transform.localPosition.x + 150, upgrade3[p2Highlight].transform.localPosition.y - 110, showSkill.player[1].skillImage[p2Highlight].transform.localPosition.z);
                    }

                    switch (p2Highlight)
                    {
                        case 0:
                            showUI.player2.popUpText.text = "1. Deals 150 damage to single enemy (30%)\r\n2. Deals 100 damage to all enemies(30 %)\r\n3. Deals 90 damage to all enemies and causes poison(20 %)\r\n4. Deals 130 damage to single enemy and causes slow(20 %)";
                            break;
                        case 1:
                            showUI.player2.popUpText.text = "1. Heals 100 HP to self (50%)\r\n2. Heals 50 HP to all allies (40%)\r\n3.Heals 50 HP for each bad status effect on character (10%)";
                            break;
                        case 2:
                            showUI.player2.popUpText.text = "1. Dispels one bad status effect on self (35%)\r\n2. Dispels one good status effect on enemy(35%)\r\n3. 20 % chance adding bless to self(20%)\r\n4. Inflicts curse to enemy(10%)";
                            break;
                    }
                }

                if (Input.GetKey("l"))
                {
                    p2Hold += Time.deltaTime;
                    if (p2Hold >= timeNeeded)
                    {
                        p2Hold = 0;
                        player2.selectedUpgrade.GetComponent<Image>().sprite = upgrade3[p2Highlight].sprite;
                        player2.upgradeIndex = p2Highlight;
                        switch (player2.upgradeIndex)
                        {
                            case 0:
                                upgradeObject2 = skillUpgrade.randomAttack();
                                break;
                            case 1:
                                upgradeObject2 = skillUpgrade.randomHeal();
                                break;
                            case 2:
                                upgradeObject2 = skillUpgrade.randomSupport();
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
                GameObject upgradeSkillObject = Instantiate(upgradeObject2);
                upgradeSkillObject.transform.parent = csm.playerList[1].transform.GetChild(1).GetChild(2 + player2.skillIndex);
                upgradeSkillObject.GetComponent<SkillEffect>().user = csm.playerList[1];
                upgradeSkillObject.GetComponent<SkillEffect>().playerArtifact = csm.playerList[1].GetComponent<PlayerArtifactEffect>();
                csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[player2.skillIndex].GetComponent<SkillDetail>().skillExecutionHolder.Add(upgradeSkillObject);
                csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[player2.skillIndex].GetComponent<SkillDetail>().upgradedCount++;
                csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[player2.skillIndex].GetComponent<SkillDetail>().upgradedEffect.Add(upgradeSkillObject.GetComponent<UpgradeDescription>().upgradeDescription);
                player2.upgradeLeft--;
                player2.upgradeState = UPGRADE_STATE.UPGRADE;
            }
            else if (player2.upgradeState == UPGRADE_STATE.UPGRADE)
            {
                player2.detail.text = csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[player2.skillIndex].GetComponent<SkillDetail>().skillName + " upgraded with " + upgradeObject2.GetComponent<UpgradeDescription>().upgradeDescription + "\r\n \r\nPress any key to continue";
                if (Input.anyKeyDown)
                {
                    showUI.player2.state = CAMPSITE_STATE.SELECTION;
                }
            }
        }
    }
}

[Serializable]
public struct CampsiteMenu
{
    public Image status;
    public Image upgrade;
    public Image ready;
    public Image highlighted;
    public Image selectedSkill;
    public Image selectedUpgrade;
    public Image fillFeedback;    
    public Text detail;
    public int skillIndex;
    public int upgradeIndex;
    public Text readyText;
    public int upgradeLeft;
    public UPGRADE_STATE upgradeState;
}

public enum UPGRADE_STATE
{
    CHOOSE_SKILL = 0,
    CHOOSE_UPGRADE,
    VALIDATE_UPGRADE,
    UPGRADE
}

[Serializable]
public struct ButtonStatus
{
    public Sprite normal;
    public Sprite chosen;
    public Sprite select;
}