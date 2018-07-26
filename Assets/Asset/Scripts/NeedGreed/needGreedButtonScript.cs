using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needGreedButtonScript : MonoBehaviour {

    public GameObject NeedGreedManager;

    public void p1GreedPressed()
    {
        NeedGreedManager.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.GREED;
    }

    public void p1NeedPressed()
    {
        NeedGreedManager.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.NEED;
    }

    public void p2GreedPressed()
    {
        NeedGreedManager.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.GREED;
    }

    public void p2NreedPressed()
    {
        NeedGreedManager.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.NEED;
    }
}
