using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDetail : MonoBehaviour {

    public string skillName;
    [TextArea]public string skillDescription;
    public int skillCooldown;
    public int maxSkillCooldown;
    public GameObject user;
    public List<GameObject> skillExecutionList;
    public List<GameObject> skillExecutionHolder;
    GameObject cooldownObject;
    public GameObject showCooldown;
    public int upgradedCount;
    public List<string> upgradedEffect;

    private void Awake()
    {
        user = this.transform.parent.parent.gameObject;
        for (int i = 0; i < skillExecutionList.Count; i++)
        {
            skillExecutionHolder.Add(Instantiate(skillExecutionList[i], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.gameObject.transform));
        }
        for (int i=0;i< skillExecutionHolder.Count;i++)
        {
            skillExecutionHolder[i].GetComponent<SkillEffect>().user = this.transform.parent.parent.gameObject;
        }
        
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        Cooldown();
	}

    void Cooldown()
    {
        if (skillCooldown > 0)
        {
            if (GetComponent<SpriteRenderer>().enabled == true)
            {
                cooldownObject = Instantiate(showCooldown);
            }
            cooldownObject.transform.position = transform.position;
            cooldownObject.GetComponentInChildren<Text>().text = skillCooldown.ToString();
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (skillCooldown <= 0)
        {
            if (GetComponent<SpriteRenderer>().enabled == false)
            {
                Destroy(cooldownObject);
            }
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
