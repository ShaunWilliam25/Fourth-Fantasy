using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionTimeBar : MonoBehaviour

{
    public Image selectionBar;
    private Color oriColor;
    public float maxSelection;
    public float startSelection;
    public string playerButton;
    public float timeRequired = 2f;
    public float xOffset;
    public float yOffset;
    Transform playerTransform;
    private PlayerScrollSkill scrollSkill;

    private void Awake()
    {
        if (this.gameObject.tag == "Player1")
        {
            playerButton = "P1_Button";
        }
        if (this.gameObject.tag == "Player2")
        {
            playerButton = "P2_Button";
        }
        scrollSkill = this.gameObject.GetComponent<PlayerScrollSkill>();
    }

    // Use this for initialization
    void Start()
    {
        startSelection = Random.Range(0, 0.51f);
        playerTransform = this.GetComponent<Transform>();
        //selectionBar.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
    }

    void Update()
    {       
        //! Increasing the bar by real time
        startSelection +=  Time.deltaTime * (1/timeRequired);

        //! Converting the value to percentage
        //float calcSelection = startSelection / 100;

        //! Checking if the calcSelection more than 1
        /*if(calcSelection >= 1)
        {
            calcSelection = 1;
        }*/

        //! Setting the value of the bar based on the calcSelection
        setSelection(startSelection);

        //! Setting location based on skillSelected from player scroll skill
        selectionBar.transform.localPosition = Camera.main.WorldToScreenPoint(new Vector2(scrollSkill.startPosition + (scrollSkill.boxOffset * scrollSkill.skillSelected) - xOffset, this.transform.position.y + yOffset));
    }

    //! Setting the amount
    void setSelection(float playerSelection)
    {
        selectionBar.fillAmount = playerSelection;
    }

    //reset back to normal;
    void repeatBar()
    {
        if (startSelection >= 100f)
        {
            startSelection = 0;
            setSelection(1);
        }
    }
}


