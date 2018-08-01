using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMenu : MonoBehaviour {
    private int choice = 1;
    [SerializeField] string playerButton;
    [SerializeField] string playerName;
    [SerializeField] Image[] selection = new Image[4];
    [SerializeField] float holdTimer = 0f;
    [SerializeField] float requiredTimer;
    [SerializeField] float timerInPercentage;
    [SerializeField] Image lobbyCanvas;
    [SerializeField] Image characterSelectionCanvas;
    [SerializeField] bool isCharacterSelected = false;
    [SerializeField] Text statusText;
    [SerializeField] LOBBY_STATE lobbyState = LOBBY_STATE.LOBBY;
    [SerializeField] List<PlayerScriptableObject> listOfCharacters;

    public enum LOBBY_STATE
    {
        LOBBY = 0,
        CHARACTER_SELECTION,
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //!Checking if the state is in the lobby for player 
        if(lobbyState == LOBBY_STATE.LOBBY)
        {
            //! Activating which pointer based on the current selection for player 
            switch (choice)
            {
                case 1:
                    if(selection[0].gameObject.activeInHierarchy != true)
                    {
                        selection[0].gameObject.SetActive(true);
                        selection[1].gameObject.SetActive(true);
                    }
                    if (selection[2].gameObject.activeInHierarchy == true)
                    {
                        selection[2].gameObject.SetActive(false);
                        selection[3].gameObject.SetActive(false);
                    }                
                    break;

                case 2:
                    if (selection[2].gameObject.activeInHierarchy != true)
                    {
                        selection[2].gameObject.SetActive(true);
                        selection[3].gameObject.SetActive(true);
                    }
                    if (selection[0].gameObject.activeInHierarchy != false)
                    {
                        selection[0].gameObject.SetActive(false);
                        selection[1].gameObject.SetActive(false);
                    }
                    break;
            }            

            //! Control to change selection for player 
            if (Input.GetButtonUp(playerButton))
            {
                choice++;
                if (choice > 2)
                {
                    choice = 1;
                }
            }
            
            //! Converting the hold timer into percentage so that can reflect with the image fill amount
            timerInPercentage = holdTimer / requiredTimer;            

            //! Reflecting the timerInPercentage with the image fill amount based on current selection
            switch (choice)
            {
                case 1:
                    //! Set the other as 0             
                    selection[3].fillAmount = 0;
                    selection[1].fillAmount = timerInPercentage;
                    break;

                case 2:
                    selection[1].fillAmount = 0;
                    selection[3].fillAmount = timerInPercentage;
                    break;
            }           

            //! Control for selecting options for player 
            if (Input.GetButton(playerButton))
            {
                holdTimer += Time.deltaTime;
            }
            //! When let go / chose another seleection
            if (Input.GetButtonUp(playerButton))
            {
                holdTimer = 0;
            }

            //! Checking for selection for player 
            //!Check if the pointer image is filled to the max
            if (timerInPercentage >= 1)
            {
                if (choice == 1)
                {
                    Debug.Log("Player 1 selected character selection");
                    //! Deactivate the lobby canvas and activate the character selection canvas
                    lobbyCanvas.enabled = false;
                    characterSelectionCanvas.enabled = true;

                }
                else if (choice == 2)
                {
                    Debug.Log("PLayer 1 selected start game");
                    //! Check if character is selected
                    if (isCharacterSelected)
                    {
                        //! Ready to start game
                        statusText.color = Color.green;
                        statusText.text = playerName + " is ready";
                    }

                    //! When character is not selected / image is null
                    //! TO BE DONE LATER
                }
                holdTimer = 0;
            }            
        }
        
        if(lobbyState == LOBBY_STATE.CHARACTER_SELECTION)
        {

        }
    }
}
