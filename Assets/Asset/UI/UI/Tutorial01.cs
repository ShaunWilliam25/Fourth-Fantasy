using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial01 : MonoBehaviour {

    public Image atb;
    public Image selectSkill;
    public Image button;
    public Sprite attackSprite;
    public Sprite defaultSprite;
    float timer;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        atb.fillAmount += 0.005f;
        selectSkill.fillAmount += 0.01f;

        if(selectSkill.fillAmount < 1)
        {
            button.color = Color.white;
        }
        else
        {
            button.color = Color.gray;
        }

        if(selectSkill.fillAmount >= 1)
        {
            selectSkill.fillAmount = 1;
        }

        if(atb.fillAmount >= 1)
        {
            selectSkill.fillAmount = 0;
            atb.fillAmount = 0;
            this.GetComponent<Image>().sprite = attackSprite;
            Debug.Log("Pew");
        }

        if(this.GetComponent<Image>().sprite == attackSprite)
        {
            timer += 0.1f;
        }

        if(timer >= 0.5f)
        {
            this.GetComponent<Image>().sprite = defaultSprite;
            timer = 0f;
        }
	}
}
