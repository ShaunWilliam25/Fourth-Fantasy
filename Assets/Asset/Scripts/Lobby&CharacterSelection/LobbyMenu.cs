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
    public int characterIndex = 1;
    [SerializeField] bool isSelectingCharacter = false;
    [SerializeField] Image[] characterSelectionPointer = new Image[4];
    public bool isReady = false;

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
                    if (selection[4].gameObject.activeInHierarchy == true)
                    {
                        selection[4].gameObject.SetActive(false);
                        selection[5].gameObject.SetActive(false);
                    }
                    break;

                case 2:
                    if (selection[2].gameObject.activeInHierarchy != true)
                    {
                        selection[2].gameObject.SetActive(true);
                        selection[3].gameObject.SetActive(true);
                    }
                    if (selection[4].gameObject.activeInHierarchy != false)
                    {
                        selection[4].gameObject.SetActive(false);
                        selection[5].gameObject.SetActive(false);
                    }
                    if (selection[0].gameObject.activeInHierarchy != false)
                    {
                        selection[0].gameObject.SetActive(false);
                        selection[1].gameObject.SetActive(false);
                    }
                    break;

                case 3:
                    if (selection[4].gameObject.activeInHierarchy != true)
                    {
                        selection[4].gameObject.SetActive(true);
                        selection[5].gameObject.SetActive(true);
                    }
                    if (selection[0].gameObject.activeInHierarchy != false)
                    {
                        selection[0].gameObject.SetActive(false);
                        selection[1].gameObject.SetActive(false);
                    }
                    if (selection[2].gameObject.activeInHierarchy == true)
                    {
                        selection[2].gameObject.SetActive(false);
                        selection[3].gameObject.SetActive(false);
                    }
                    break;
            }            

            //! Control to change selection for player 
            if (Input.GetButtonUp(playerButton))
            {
                choice++;
                if (choice > 3)
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
                    selection[5].fillAmount = 0;
                    selection[3].fillAmount = 0;
                    selection[1].fillAmount = timerInPercentage;
                    break;

                case 2:
                    selection[1].fillAmount = 0;
                    selection[5].fillAmount = 0;
                    selection[3].fillAmount = timerInPercentage;
                    break;

                case 3:
                    selection[1].fillAmount = 0;
                    selection[3].fillAmount = 0;
                    selection[5].fillAmount = timerInPercentage;
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
                    //! Deactivate the lobby canvas and activate the character selection canvas
                    lobbyCanvas.gameObject.SetActive(false);
                    characterSelectionCanvas.gameObject.SetActive(true);
                    holdTimer = 0f;
                    lobbyState = LOBBY_STATE.CHARACTER_SELECTION;

                }
                else if (choice == 2)
                {
                    //! Check if character is selected
                    if (isCharacterSelected)
                    {
                        //! Ready to start game
                        statusText.color = Color.green;
                        statusText.text = playerName + " is ready";
                        isReady = true;
                    }

                    //! When character is not selected / image is null
                    if(lobbyCanvas.transform.GetChild(1).GetComponent<Image>().sprite == null)
                    {
                        statusText.color = Color.red;
                        statusText.text = "You must first selec a character to play as";
                    }
                }
                else if(choice == 3)
                {
                    holdTimer = 0;
                }
                holdTimer = 0;
            }
        }
        
        if(lobbyState == LOBBY_STATE.CHARACTER_SELECTION)
        {
            //! Make sure that the isCharacter selected is false
            if(isCharacterSelected)
            {
                isCharacterSelected = false;
            }

            //! Reset the status text
            if(statusText.text != null)
            {
                statusText.text = null;
            }

            //! Empty the picture
            if(lobbyCanvas.transform.GetChild(1).GetComponent<Image>().sprite != null)
            {
                lobbyCanvas.transform.GetChild(1).GetComponent<Image>().sprite = null;
            }

            //! Reset the color alpha
            if (lobbyCanvas.transform.GetChild(1).GetComponent<Image>().color.a > 0)
            {
                lobbyCanvas.transform.GetChild(1).GetComponent<Image>().color = new Vector4(255, 255, 255, 0);
            }

            //! Reset the isReady bool
            if(isReady)
            {
                isReady = false;
            }
            
            //! Displaying all the information of characters
            Transform characterCanvasTransform = characterSelectionCanvas.transform;

            //! Display name of the character
            characterCanvasTransform.GetChild(0).GetComponent<Text>().text = listOfCharacters[characterIndex].name;

            //! Display sprite of the character
            characterCanvasTransform.GetChild(1).GetComponent<Image>().sprite = listOfCharacters[characterIndex].sprite;

            //! Display Health of character
            characterCanvasTransform.GetChild(2).GetComponent<Text>().text = "HP: " + listOfCharacters[characterIndex].health + " / " + listOfCharacters[characterIndex].maxHealth;

            //! Display Skill details of character
            for(int i=0;i<5;i++)
            {
                //!Display skill spirte
                characterCanvasTransform.GetChild(6 + i).GetChild(0).GetComponent<Image>().sprite = listOfCharacters[characterIndex].skillImages[i];

                //! Display skill name
                characterCanvasTransform.GetChild(6 + i).GetChild(1).GetComponent<Text>().text = listOfCharacters[characterIndex].skillNames[i];

                //! Display skill description
                characterCanvasTransform.GetChild(6 + i).GetChild(2).GetComponent<Text>().text = listOfCharacters[characterIndex].skillDescriptions[i];
            }

            //! Selection of characters(yes / no buttons)

            //! Pointer active based on boolean
            if(isSelectingCharacter)
            {
                //! Check if already active
                if(characterSelectionPointer[0].gameObject.activeInHierarchy == false)
                {
                    characterSelectionPointer[0].gameObject.SetActive(true);
                }
                if (characterSelectionPointer[1].gameObject.activeInHierarchy == false)
                {
                    characterSelectionPointer[1].gameObject.SetActive(true);
                }

                //! Off deactivate the other 2
                //! Check if already active
                if (characterSelectionPointer[2].gameObject.activeInHierarchy == true)
                {
                    characterSelectionPointer[2].gameObject.SetActive(false);
                }
                if (characterSelectionPointer[3].gameObject.activeInHierarchy == true)
                {
                    characterSelectionPointer[3].gameObject.SetActive(false);
                }
            }
            else
            {
                //! Check if already active
                if (characterSelectionPointer[2].gameObject.activeInHierarchy == false)
                {
                    characterSelectionPointer[2].gameObject.SetActive(true);
                }
                if (characterSelectionPointer[3].gameObject.activeInHierarchy == false)
                {
                    characterSelectionPointer[3].gameObject.SetActive(true);
                }

                //! Off deactivate the other 2
                //! Check if already active
                if (characterSelectionPointer[0].gameObject.activeInHierarchy == true)
                {
                    characterSelectionPointer[0].gameObject.SetActive(false);
                }
                if (characterSelectionPointer[1].gameObject.activeInHierarchy == true)
                {
                    characterSelectionPointer[1].gameObject.SetActive(false);
                }
            }
            //! Scrolling of the pointer
            if(Input.GetButtonUp(playerButton))
            {
                if(isSelectingCharacter == true)
                {
                    isSelectingCharacter = false;
                }
                else
                {
                    isSelectingCharacter = true;
                }
            }

            //! Converting the hold timer into percentage so that can reflect with the image fill amount
            timerInPercentage = holdTimer / requiredTimer;

            //! Reflecting the timerInPercentage with the image fill amount based on current selection
            switch (isSelectingCharacter)
            {
                case true:
                    //! Set the other as 0             
                    characterSelectionPointer[3].fillAmount = 0;
                    characterSelectionPointer[1].fillAmount = timerInPercentage;
                    break;

                case false:
                    characterSelectionPointer[1].fillAmount = 0;
                    characterSelectionPointer[3].fillAmount = timerInPercentage;
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

            //! When the pointer charges finish
            if(timerInPercentage >= 1)
            {
                //! Check if yes
                if(isSelectingCharacter)
                {
                    //! Reset hold timer
                    holdTimer = 0f;

                    //! Close the character selection canvas
                    characterSelectionCanvas.gameObject.SetActive(false);                    

                    //! Open the lobby canvas
                    lobbyCanvas.gameObject.SetActive(true);

                    //! Change the image for the lobby canvas Image
                    lobbyCanvas.transform.GetChild(1).GetComponent<Image>().sprite = listOfCharacters[characterIndex].sprite;
                    lobbyCanvas.transform.GetChild(1).GetComponent<Image>().color = new Vector4(255, 255, 255, 255);

                    //! Change the lobby state
                    lobbyState = LOBBY_STATE.LOBBY;

                    //! Change the isCharacter selected bool
                    isCharacterSelected = true;
                }

                //! Check if no
                else
                {
                    //! Rest hold timer
                    holdTimer = 0;

                    //! Change the character index
                    characterIndex++;

                    //! If the index is over the count of the list
                    if(characterIndex >= listOfCharacters.Count)
                    {
                        characterIndex = 0;
                    }
                }
            }

        }
    }
}
