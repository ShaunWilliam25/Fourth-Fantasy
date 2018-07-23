using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CampsiteSelection : MonoBehaviour
{
    //EventSystem campsiteES;
    public Button p1StatusCheck;
    public Button p1UpgradeSkill;
    public Button p2StatusCheck;
    public Button p2UpgradeSkill;
    public GameObject p1statusUI;
    public GameObject p1UpgradeUI;
    public GameObject p2statusUI;
    public GameObject p2UpgradeUI;
    public float timeNeeded;
    public float p1Hold,p2Hold;

    void OnEnable()
    {
        //campsiteES = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            if(p1StatusCheck.GetComponent<Image>().color == Color.red)
            {
                p1StatusCheck.GetComponent<Image>().color = Color.white;
                p1UpgradeSkill.GetComponent<Image>().color = Color.red;
            }
            else
            {
                p1StatusCheck.GetComponent<Image>().color = Color.red;
                p1UpgradeSkill.GetComponent<Image>().color = Color.white;
            }
        }

        if (Input.GetKeyUp("l"))
        {
            if (p1StatusCheck.GetComponent<Image>().color == Color.blue)
            {
                p2StatusCheck.GetComponent<Image>().color = Color.white;
                p2UpgradeSkill.GetComponent<Image>().color = Color.blue;
            }
            else
            {
                p2StatusCheck.GetComponent<Image>().color = Color.blue;
                p2UpgradeSkill.GetComponent<Image>().color = Color.white;
            }
        }

        if(Input.GetKeyDown("a"))
        {
            p1Hold += Time.deltaTime;
            if (p1Hold > timeNeeded)
            {
                if (p1StatusCheck.GetComponent<Image>().color == Color.red)
                {
                    p1statusUI.SetActive(true);
                }
                else
                {
                    p1UpgradeUI.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown("l"))
        {
            p2Hold += Time.deltaTime;
            if (p2Hold > timeNeeded)
            {
                if (p2StatusCheck.GetComponent<Image>().color == Color.red)
                {
                    p2statusUI.SetActive(true);
                }
                else
                {
                    p2UpgradeUI.SetActive(true);
                }
            }
        }

        p1Hold = 0;
        p2Hold = 0;

    }
}