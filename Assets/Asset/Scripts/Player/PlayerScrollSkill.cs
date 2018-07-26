using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScrollSkill : PlayerVariableManager {

    public int   isScroll = 0;

    [SerializeField] private GameObject skillBox;
    private Transform boxPos;
    public int skillSelected = 0;
    [SerializeField] private float boxOffset = 0f;
    [SerializeField] private Vector3 boxStartPosition = new Vector3(-1.2f,0f,0f);

    private void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        boxPos = skillBox.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.CHOOSING_SKILL)
        {
            Scroll();
        }
    }

    void Scroll()
    {
        /*//! adjusting the position of the skill
        for (int i=0;i< this.GetComponent<PlayerVariableManager>().skillHolder.Count;i++)
        {
            this.GetComponent<PlayerVariableManager>().skillHolder[i].transform.position = new Vector2(this.transform.GetChild(1).transform.position.x - this.GetComponent<PlayerVariableManager>().offset + (i*0.62f) , this.transform.GetChild(1).transform.position.y);
        }

        if(Input.GetButtonUp(this.GetComponent<PlayerVariableManager>().playerButton))
        {
            this.GetComponent<PlayerVariableManager>().tempSkill = this.GetComponent<PlayerVariableManager>().skillHolder[4];
            for(int i=0;i< this.GetComponent<PlayerVariableManager>().skillHolder.Count - 1;i++)
            {
                this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count - 1 - i] = this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count - 1 - i - 1];
            }
            this.GetComponent<PlayerVariableManager>().skillHolder[0] = this.GetComponent<PlayerVariableManager>().tempSkill;
            isScroll ++;
        }*/

        if (Input.GetButtonUp(this.GetComponent<PlayerVariableManager>().playerButton))
        {
            //! Move the box & and also the int for which skill its at
            skillSelected++;

            //! Move the box
            skillBox.transform.Translate(new Vector3(boxOffset, 0, 0));

            //! Check if the box is over the skill list
            if (skillSelected > 4)
            {
                skillSelected = 0;

                //! Set the box location to the first one
                boxPos.position = boxStartPosition;
                Debug.Log("REset position");
            }
        }            
    }
}
