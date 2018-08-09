using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NeedGreedSelection : MonoBehaviour
{
    public Button p1Need;
    public Button p1Greed;
    public Button p2Need;
    public Button p2Greed;
    public float timeNeeded = 1;
    public float p1Hold, p2Hold;
    public Image imageFill1;
    public Image imageFill2;
    public Color p1NeedImageColor;
    public Color p1GreedImageColor;
    public Color p2NeedImageColor;
    public Color p2GreedImageColor;
    public needGreedShowUI NeedGreedShowUI;

    private void Awake()
    {
        p1NeedImageColor = p1Need.GetComponent<Image>().color;
        p1GreedImageColor = p1Greed.GetComponent<Image>().color;
        p2NeedImageColor = p2Need.GetComponent<Image>().color;
        p2GreedImageColor = p2Greed.GetComponent<Image>().color;
        NeedGreedShowUI = GetComponent<needGreedShowUI>();
    }

    private void Start()
    {
        p1NeedImageColor = Color.red;
        p2NeedImageColor = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            if (p1NeedImageColor == Color.red)
            {
                p1NeedImageColor = Color.white;
                p1GreedImageColor = Color.red;
                imageFill1.transform.position = p1Greed.transform.position;
            }
            else
            {
                p1NeedImageColor = Color.red;
                p1GreedImageColor = Color.white;
                imageFill1.transform.position = p1Need.transform.position;
            }
        }

        if (Input.GetKeyUp("l"))
        {
            if (p2NeedImageColor == Color.blue)
            {
                p2NeedImageColor = Color.white;
                p2GreedImageColor = Color.blue;
                imageFill2.transform.position = p2Greed.transform.position;
            }
            else
            {
                p2NeedImageColor = Color.blue;
                p2GreedImageColor = Color.white;
                imageFill2.transform.position = p2Need.transform.position;
            }
        }

        if (Input.GetKey("a"))
        {
            p1Hold += Time.deltaTime;
            imageFill1.fillAmount = p1Hold;
            if (p1Hold > timeNeeded)
            {
                if (p1NeedImageColor == Color.red)
                {
                    NeedGreedShowUI.p1State = needGreedShowUI.CAMPSITE_STATE.GREED;
                }
                else
                {
                    NeedGreedShowUI.p1State = needGreedShowUI.CAMPSITE_STATE.NEED;
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
                if (p2NeedImageColor == Color.blue)
                {
                    NeedGreedShowUI.p2State = needGreedShowUI.CAMPSITE_STATE.GREED;
                }
                else
                {
                    NeedGreedShowUI.p2State = needGreedShowUI.CAMPSITE_STATE.NEED;
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