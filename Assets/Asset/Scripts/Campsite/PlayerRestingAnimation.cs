using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestingAnimation : MonoBehaviour {

    CampsiteManager csm;
    public Animator[] anim = new Animator[2];

	void Start ()
    {
        csm = this.GetComponent<CampsiteManager>();
        for(int i = 0; i < csm.playerList.Count; i++)
        {
            Debug.Log(i);
            Debug.Log(csm.playerList[i].GetComponent<PlayerStats>().name);
            if(csm.playerList[i].GetComponent<PlayerStats>().name == "ExiledDemon")
            {
               anim[i].GetComponent<Animator>().Play("ExiledDemonResting" + (i+1));
            }
            else if (csm.playerList[i].GetComponent<PlayerStats>().name == "TimePriestess")
            {
                anim[i].GetComponent<Animator>().Play("TimePriestessResting" + (i+1));
            }
            else if (csm.playerList[i].GetComponent<PlayerStats>().name == "OldGuard")
            {
                anim[i].GetComponent<Animator>().Play("OldGuardResting" + (i+1));
            }

        }
	}
}
