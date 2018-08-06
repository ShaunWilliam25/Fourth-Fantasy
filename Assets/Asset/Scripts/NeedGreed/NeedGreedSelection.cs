using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NeedGreedSelection : MonoBehaviour
{
    //EventSystem campsiteES;
    public Button p1Need;
    public Button p1Greed;
    public Button p2Need;
    public Button p2Greed;
    public float timeNeeded = 1;
    public float p1Hold, p2Hold;
    public Image imageFill1;
    public Image imageFill2;

    private void Start()
    {
        p1Need.GetComponent<Image>().color = Color.red;
        p2Need.GetComponent<Image>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            if (p1Need.GetComponent<Image>().color == Color.red)
            {
                p1Need.GetComponent<Image>().color = Color.white;
                p1Greed.GetComponent<Image>().color = Color.red;
                imageFill1.transform.position = p1Greed.transform.position;
            }
            else
            {
                p1Need.GetComponent<Image>().color = Color.red;
                p1Greed.GetComponent<Image>().color = Color.white;
                imageFill1.transform.position = p1Need.transform.position;
            }
        }

        if (Input.GetKeyUp("l"))
        {
            if (p2Need.GetComponent<Image>().color == Color.blue)
            {
                p2Need.GetComponent<Image>().color = Color.white;
                p2Greed.GetComponent<Image>().color = Color.blue;
                imageFill2.transform.position = p2Greed.transform.position;
            }
            else
            {
                p2Need.GetComponent<Image>().color = Color.blue;
                p2Greed.GetComponent<Image>().color = Color.white;
                imageFill2.transform.position = p2Need.transform.position;
            }
        }

        if (Input.GetKey("a"))
        {
            p1Hold += Time.deltaTime;
            imageFill1.fillAmount = p1Hold;
            if (p1Hold > timeNeeded)
            {
                if (p1Need.GetComponent<Image>().color == Color.red)
                {
                    this.GetComponent<needGreedShowUI>().p1State = needGreedShowUI.CAMPSITE_STATE.GREED;
                }
                else
                {
                    this.GetComponent<needGreedShowUI>().p1State = needGreedShowUI.CAMPSITE_STATE.NEED;
                }
            }
        }
        else
        {
            p1Hold = 0;
            imageFill1.fillAmount = p1Hold;
        }

        if (Input.GetKey("l"))
        {
            p2Hold += Time.deltaTime;
            imageFill2.fillAmount = p2Hold;
            if (p2Hold > timeNeeded)
            {
                if (p2Need.GetComponent<Image>().color == Color.blue)
                {
                    this.GetComponent<needGreedShowUI>().p2State = needGreedShowUI.CAMPSITE_STATE.GREED;
                }
                else
                {
                    this.GetComponent<needGreedShowUI>().p2State = needGreedShowUI.CAMPSITE_STATE.NEED;
                }
            }
        }
        else
        {
            p2Hold = 0;
            imageFill2.fillAmount = p2Hold;
        }
    }
}
/*
public class NeedGreedSelection : MonoBehaviour
{
    //EventSystem campsiteES;
    public Text p1Need;
    public Text p1Greed;
    public Text p2Need;
    public Text p2Greed;
    public float timeNeeded = 1;
    public float p1Hold, p2Hold;
    public Image imageFill1;
    public Image imageFill2;

    void OnEnable()
    {
        //campsiteES = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            if (p1Need.GetComponent<Text>().color == Color.red)
            {
                p1Need.GetComponent<Text>().color = Color.white;
                p1Greed.GetComponent<Text>().color = Color.red;
            }
            else
            {
                p1Need.GetComponent<Text>().color = Color.red;
                p1Greed.GetComponent<Text>().color = Color.white;
            }
        }

        if (Input.GetKeyUp("l"))
        {
            if (p2Need.GetComponent<Text>().color == Color.blue)
            {
                p2Need.GetComponent<Text>().color = Color.white;
                p2Greed.GetComponent<Text>().color = Color.blue;
            }
            else
            {
                p2Need.GetComponent<Text>().color = Color.blue;
                p2Greed.GetComponent<Text>().color = Color.white;
            }
        }

        if (Input.GetKey("a"))
        {
            p1Hold += Time.deltaTime;
            imageFill1.fillAmount = p1Hold;
            if (p1Hold > timeNeeded)
            {
                if (p1Need.GetComponent<Text>().color == Color.red)
                {
                    this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.GREED;
                }
                else
                {
                    this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.NEED;
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
            imageFill2.fillAmount = p2Hold;
            if (p2Hold > timeNeeded)
            {
                if (p2Need.GetComponent<Text>().color == Color.blue)
                {
                    this.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.GREED;
                }
                else
                {
                    this.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.NEED;
                }
            }
        }
        else
        {
            p2Hold = 0;
        }
    }
}
*/