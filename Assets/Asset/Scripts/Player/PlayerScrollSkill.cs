using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScrollSkill : PlayerVariableManager {

    public int isScroll = 0;

    [SerializeField] private GameObject skillBox;
    private Transform boxPos;
    public int skillSelected = 0;
    public float boxOffset = 0f;
    public float startPosition;
    [SerializeField] private float characterOffset;

    void Start()
    {
        boxPos = skillBox.transform;
        startPosition = this.GetComponent<Transform>().position.x - 1.2f;
        isScroll = 0;
    }

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

        if (GetComponent<PlayerStats>().silence)
        {
            if (this.GetComponent<PlayerVariableManager>().skillHolder[2].GetComponent<SkillDetail>().skillName == "Normal Attack")
            {
                return;
            }
            else
            {
                do
                {
                    this.GetComponent<PlayerVariableManager>().tempSkill = this.GetComponent<PlayerVariableManager>().skillHolder[4];
                    for (int i = 0; i < this.GetComponent<PlayerVariableManager>().skillHolder.Count - 1; i++)
                    {
                        this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count - 1 - i] = this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count - 1 - i - 1];
                    }
                    this.GetComponent<PlayerVariableManager>().skillHolder[0] = this.GetComponent<PlayerVariableManager>().tempSkill;
                } while (this.GetComponent<PlayerVariableManager>().skillHolder[2].GetComponent<SkillDetail>().skillName != "Normal Attack");
                return;
            }
        }

        if (Input.GetButtonUp(this.GetComponent<PlayerVariableManager>().playerButton))
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
            //! Silence check
            if (GetComponent<PlayerStats>().silence || GetComponent<PlayerStats>().berserk)
            {
                //if (this.GetComponent<PlayerVariableManager>().skillHolder[skillSelected].GetComponent<SkillDetail>().skillName == "Normal Attack")
                if (skillSelected == 2)
                {
                    return;
                }
                else
                {
                    skillSelected = 2;
                    boxPos.position = new Vector3(startPosition + (boxOffset * skillSelected), -characterOffset, 0);
                    return;
                }
            }
            
            //! Move the box & and also the int for which skill its at
            skillSelected++;

            //! Check if the box is over the skill list
            if (skillSelected > 4)
            {
                skillSelected = 0;
                boxPos.position = new Vector3(startPosition,-0.98f,0);
            }

            //! Move the box
            //skillBox.transform.Translate(new Vector3(boxOffset, 0, 0));
            boxPos.position = new Vector3(startPosition  + (boxOffset* skillSelected), -characterOffset, 0);

            //! The variable for the tutorial
            if(isScroll < 3)
            {
                //isScroll++;
            }
            isScroll++;

            //! Check if the isScroll is more than than than requirement
            if(isScroll > 3)
            {
                isScroll = 3;
            }
        }            
    }
}
