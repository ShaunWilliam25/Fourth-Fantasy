using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needGreedButtonScript : MonoBehaviour {

    public GameObject NeedGreedManager;

    public void p1GreedPressed()
    {
        NeedGreedManager.GetComponent<needGreedShowUI>().p1State = needGreedShowUI.CAMPSITE_STATE.GREED;
    }

    public void p1NeedPressed()
    {
        NeedGreedManager.GetComponent<needGreedShowUI>().p1State = needGreedShowUI.CAMPSITE_STATE.NEED;
    }

    public void p2GreedPressed()
    {
        NeedGreedManager.GetComponent<needGreedShowUI>().p2State = needGreedShowUI.CAMPSITE_STATE.GREED;
    }

    public void p2NreedPressed()
    {
        NeedGreedManager.GetComponent<needGreedShowUI>().p2State = needGreedShowUI.CAMPSITE_STATE.NEED;
    }
}
