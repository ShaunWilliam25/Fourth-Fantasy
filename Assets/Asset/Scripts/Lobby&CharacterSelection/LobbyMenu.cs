using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMenu : MonoBehaviour {
    private int p1Choice = 1;
    private int p2Choice = 1;
    [SerializeField] Image[] p1Selection = new Image[4];
    [SerializeField] Image[] p2Selection = new Image[4];
    [SerializeField] float p1HoldTimer = 0f;
    [SerializeField] float p2HoldTimer = 0f;
    [SerializeField] float p1RequiredTimer;
    [SerializeField] float p2RequiredTimer;
    [SerializeField] float p1TimerInPercentage;
    [SerializeField] float p2TimerInPercentage;

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
                if(p1Selection[0].gameObject.activeInHierarchy != true)
                {
                    p1Selection[0].gameObject.SetActive(true);
                    p1Selection[1].gameObject.SetActive(true);
                }
                if (p1Selection[2].gameObject.activeInHierarchy == true)
                {
                    p1Selection[2].gameObject.SetActive(false);
                    p1Selection[3].gameObject.SetActive(false);
                }                
                break;

            case 2:
                if (p1Selection[2].gameObject.activeInHierarchy != true)
                {
                    p1Selection[2].gameObject.SetActive(true);
                    p1Selection[3].gameObject.SetActive(true);
                }
                if (p1Selection[0].gameObject.activeInHierarchy != false)
                {
                    p1Selection[0].gameObject.SetActive(false);
                    p1Selection[1].gameObject.SetActive(false);
                }
                break;
        }

        //! Activating which pointer based on the current selection for player 2
        switch (p2Choice)
        {
            case 1:
                if (p2Selection[0].gameObject.activeInHierarchy != true)
                {
                    p2Selection[0].gameObject.SetActive(true);
                    p2Selection[1].gameObject.SetActive(true);
                }
                if (p2Selection[2].gameObject.activeInHierarchy != false)
                {
                    p2Selection[2].gameObject.SetActive(false);
                    p2Selection[3].gameObject.SetActive(false);
                }
                break;

            case 2:
                if (p2Selection[0].gameObject.activeInHierarchy != false)
                {
                    p2Selection[0].gameObject.SetActive(false);
                    p2Selection[1].gameObject.SetActive(false);
                }
                if (p2Selection[2].gameObject.activeInHierarchy != true)
                {
                    p2Selection[2].gameObject.SetActive(true);
                    p2Selection[3].gameObject.SetActive(true);
                }
                break;
        }

        //! Control to change selection for player 1
        if(Input.GetButtonUp("P1_Button"))
        {
            p1Choice++;
            if (p1Choice > 2)
            {
                p1Choice = 1;
            }
        }

        //! Control to change the selection for player 2
        if (Input.GetButtonUp("P2_Button"))
        {
            p2Choice++;
            if (p2Choice > 2)
            {
                p2Choice = 1;
            }
        }


        //! Converting the hold timer into percentage so that can reflect with the image fill amount
        p1TimerInPercentage = p1HoldTimer / p1RequiredTimer;
        p2TimerInPercentage = p2HoldTimer / p2RequiredTimer;

        //! Reflecting the timerInPercentage with the image fill amount based on current selection
        switch(p1Choice)
        {
            case 1:
                //! Set the other as 0             
                p1Selection[3].fillAmount = 0;
                p1Selection[1].fillAmount = p1TimerInPercentage;
                break;

            case 2:
                p1Selection[1].fillAmount = 0;
                p1Selection[3].fillAmount = p1TimerInPercentage;
                break;
        }

        switch (p2Choice)
        {
            case 1:
                p2Selection[3].fillAmount = 0;
                p2Selection[1].fillAmount = p2TimerInPercentage;
                break;

            case 2:
                p2Selection[1].fillAmount = 0;
                p2Selection[3].fillAmount = p2TimerInPercentage;
                break;
        }


        //! Control for selecting options for player 1
        if (Input.GetButton("P1_Button"))
        {
            p1HoldTimer += Time.deltaTime;
        }
        //! When let go / chose another seleection
        if(Input.GetButtonUp("P1_Button"))
        {
            p1HoldTimer = 0;
        }

        //! Control for selecting options for player 2
        if (Input.GetButton("P2_Button"))
        {
            p2HoldTimer += Time.deltaTime;
        }
        //! When let go / chose another seleection
        if (Input.GetButtonUp("P2_Button"))
        {
            p2HoldTimer = 0;
        }

        //! Checking for selection for player 1
        //!Check if the pointer image is filled to the max
        if(p1TimerInPercentage >= 1)
        {
            if(p1Choice == 1)
            {
                Debug.Log("Player 1 selected character selection");
            }
            else if(p1Choice == 2)
            {
                Debug.Log("PLayer 1 selected start game");
            }
        }

        //! Checking for selection for player 2
        //!Check if the pointer image is filled to the max
        if (p2TimerInPercentage >= 1)
        {
            if (p2Choice == 1)
            {
                Debug.Log("Player 2 selected character selection");
            }
            else if (p2Choice == 2)
            {
                Debug.Log("PLayer 2 selected start game");
            }
        }
    }
}
