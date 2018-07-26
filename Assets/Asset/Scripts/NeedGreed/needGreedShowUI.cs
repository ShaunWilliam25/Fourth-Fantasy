using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needGreedShowUI : MonoBehaviour
{
    public GameObject p1Select;
    public GameObject p1Need;
    public GameObject p1Greed;
    public GameObject p2Select;
    public GameObject p2Need;
    public GameObject P2Greed;
    public bool greed1 = false;
    public bool greed2 = false;
    public bool need1 = false;
    public bool need2 = false;
    public bool selected1 = false;
    public bool selected2 = false;

    public enum CAMPSITE_STATE
    {
        SELECTION = 0,
        GREED,
        NEED
    }

    public CAMPSITE_STATE p1State;
    public CAMPSITE_STATE p2State;

    void Start()
    {
        p1State = CAMPSITE_STATE.SELECTION;
        p2State = CAMPSITE_STATE.SELECTION;
    }

    void Update()
    {
        if (p1State == CAMPSITE_STATE.SELECTION)
        {
            p1Select.SetActive(true);
            p1Need.SetActive(false);
            p1Greed.SetActive(false);
        }
        else if (p1State == CAMPSITE_STATE.GREED)
        {
            p1Select.SetActive(false);
            p1Need.SetActive(false);
            p1Greed.SetActive(true);
            greed1 = true;
            selected1 = true;
        }
        else if (p1State == CAMPSITE_STATE.NEED)
        {
            p1Select.SetActive(false);
            p1Need.SetActive(true);
            p1Greed.SetActive(false);
            need1 = true;
            selected1 = true;
        }

        if (p2State == CAMPSITE_STATE.SELECTION)
        {
            p2Select.SetActive(true);
            p2Need.SetActive(false);
            P2Greed.SetActive(false);
        }
        else if (p2State == CAMPSITE_STATE.GREED)
        {
            p2Select.SetActive(false);
            p2Need.SetActive(false);
            P2Greed.SetActive(true);
            greed2 = true;
            selected2 = true;
        }
        else if (p2State == CAMPSITE_STATE.NEED)
        {
            p2Select.SetActive(false);
            p2Need.SetActive(true);
            P2Greed.SetActive(false);
            need2 = true;
            selected2 = true;
        }
    }
}