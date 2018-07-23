using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampsiteSelection : MonoBehaviour
{
    public Button p1StatusCheck;
    public Button p1UpgradeSkill;
    public Button p2StatusCheck;
    public Button p2UpgradeSkill;
    public Text p1Ready;
    public Text p2Ready;
    public Text p1Back;
    public Text p2Back;
    public float timeNeeded = 1;
    public float p1Hold, p2Hold;
    ShowUI showUI;
    ShowSkill showSkill;
    public int highlight = 0;
    public GameObject highlighted;

    void Start()
    {
        showUI = GetComponent<ShowUI>();
        showSkill = GetComponent<ShowSkill>();
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
                    if (p1StatusCheck.GetComponent<Image>().color == Color.red)
                    {
                        showUI.player1.state = CAMPSITE_STATE.STATUS_CHECK;
                    }
                    else if (p1UpgradeSkill.GetComponent<Image>().color == Color.red)
                    {
                        showUI.player1.state = CAMPSITE_STATE.SKILL_UPGRADE;
                    }
                    else if (p1Ready.GetComponent<Text>().color == Color.yellow)
                    {
                        p1Ready.GetComponent<Text>().color = Color.green;
                        showUI.player1.state = CAMPSITE_STATE.READY;
                    }
                }
                else if (this.GetComponent<ShowUI>().player1.state == CAMPSITE_STATE.READY)
                {
                    p1Hold = 0;
                    p1Ready.GetComponent<Text>().color = Color.yellow;
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
                    if (p2StatusCheck.GetComponent<Image>().color == Color.blue)
                    {
                        showUI.player2.state = CAMPSITE_STATE.STATUS_CHECK;
                    }
                    else if (p2UpgradeSkill.GetComponent<Image>().color == Color.blue)
                    {
                        showUI.player2.state = CAMPSITE_STATE.SKILL_UPGRADE;
                    }
                    else if (p2Ready.GetComponent<Text>().color == Color.yellow)
                    {
                        p2Ready.GetComponent<Text>().color = Color.green;
                        showUI.player2.state = CAMPSITE_STATE.READY;
                    }
                }
                else if (this.GetComponent<ShowUI>().player2.state == CAMPSITE_STATE.READY)
                {
                    p2Hold = 0;
                    p2Ready.GetComponent<Text>().color = Color.yellow;
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
                if (p1StatusCheck.GetComponent<Image>().color == Color.red)
                {
                    p1StatusCheck.GetComponent<Image>().color = Color.white;
                    p1UpgradeSkill.GetComponent<Image>().color = Color.red;
                }
                else if (p1UpgradeSkill.GetComponent<Image>().color == Color.red)
                {
                    p1UpgradeSkill.GetComponent<Image>().color = Color.white;
                    p1Ready.GetComponent<Text>().color = Color.yellow;
                }
                else if (p1Ready.GetComponent<Text>().color == Color.yellow)
                {
                    p1StatusCheck.GetComponent<Image>().color = Color.red;
                    p1Ready.color = Color.white;
                }
            }
        }

        if (showUI.player2.state == CAMPSITE_STATE.SELECTION)
        {
            if (Input.GetKeyUp("l"))
            {
                if (p2StatusCheck.GetComponent<Image>().color == Color.blue)
                {
                    p2StatusCheck.GetComponent<Image>().color = Color.white;
                    p2UpgradeSkill.GetComponent<Image>().color = Color.blue;
                }
                else if (p2UpgradeSkill.GetComponent<Image>().color == Color.blue)
                {
                    p2UpgradeSkill.GetComponent<Image>().color = Color.white;
                    p2Ready.GetComponent<Text>().color = Color.yellow;
                }
                else if (p2Ready.GetComponent<Text>().color == Color.yellow)
                {
                    p2StatusCheck.GetComponent<Image>().color = Color.blue;
                    p2Ready.color = Color.white;
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
        if (showUI.player1.state == CAMPSITE_STATE.STATUS_CHECK || showUI.player1.state == CAMPSITE_STATE.SKILL_UPGRADE /*|| showUI.player1.state == CAMPSITE_STATE.READY*/)
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
                    else if (showUI.player1.state == CAMPSITE_STATE.SKILL_UPGRADE)
                    {
                        showUI.player1.state = CAMPSITE_STATE.SELECTION;
                    }
                    /*else if (showUI.player1.state == CAMPSITE_STATE.READY)
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

        if (showUI.player2.state == CAMPSITE_STATE.STATUS_CHECK || showUI.player2.state == CAMPSITE_STATE.SKILL_UPGRADE /*|| showUI.player2.state == CAMPSITE_STATE.READY*/)
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
                    else if (showUI.player2.state == CAMPSITE_STATE.SKILL_UPGRADE)
                    {
                        showUI.player2.state = CAMPSITE_STATE.SELECTION;
                    }
                    /*else if (showUI.player2.state == CAMPSITE_STATE.READY)
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
            if (Input.GetKeyUp("a"))
            {
                if( highlight < 4)
                {
                    highlight++;
                }
                else
                {
                    highlight = 0;
                }
            }
            highlighted.transform.localPosition = showSkill.player[0].skillImage[highlight].transform.localPosition;
        }
    }
}
