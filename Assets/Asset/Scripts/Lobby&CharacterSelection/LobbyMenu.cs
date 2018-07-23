using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMenu : MonoBehaviour {
    private int p1Choice = 1;
    private int p2Choice = 1;
    [SerializeField] Image p1Character;
    [SerializeField] Image p2Character;
    [SerializeField] Image p1Start;
    [SerializeField] Image p2Start;
    [SerializeField] Image[] p1Selection = new Image[2];
    [SerializeField] Image[] p2Selection = new Image[2];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //! Activating which pointer based on the current selection for player 1
        switch (p1Choice)
        {
            case 1:
                if(p1Character.gameObject.activeInHierarchy != true)
                {
                    p1Character.gameObject.SetActive(true);
                }
                if (p1Start.gameObject.activeInHierarchy != false)
                {
                    p1Start.gameObject.SetActive(false);
                }                
                break;

            case 2:
                if (p1Character.gameObject.activeInHierarchy != false)
                {
                    p1Character.gameObject.SetActive(false);
                }
                if (p1Start.gameObject.activeInHierarchy != true)
                {
                    p1Start.gameObject.SetActive(true);
                }
                break;
        }
        //! Array method of activating selection(STOPPED HERE)

        //! Activating which pointer based on the current selection for player 2
        switch (p2Choice)
        {
            case 1:
                if (p2Character.gameObject.activeInHierarchy != true)
                {
                    p2Character.gameObject.SetActive(true);
                }
                if (p2Start.gameObject.activeInHierarchy != false)
                {
                    p2Start.gameObject.SetActive(false);
                }
                break;

            case 2:
                if (p2Character.gameObject.activeInHierarchy != false)
                {
                    p2Character.gameObject.SetActive(false);
                }
                if (p2Start.gameObject.activeInHierarchy != true)
                {
                    p2Start.gameObject.SetActive(true);
                }
                break;
        }

        //! Control to change selection for player 1
        if(Input.GetButtonDown("P1_Button"))
        {
            p1Choice++;
            if (p1Choice > 2)
            {
                p1Choice = 1;
            }
        }

        //! Control to change the selection for player 2
        if (Input.GetButtonDown("P2_Button"))
        {
            p2Choice++;
            if (p2Choice > 2)
            {
                p2Choice = 1;
            }
        }
    }
}
