using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDescription : MonoBehaviour {

    private Text skillDescription;
    private Text skillName;
    private GameObject holder;
    Transform playerTransform;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
    [SerializeField] private PlayerScrollSkill scrollSkill;
    // Use this for initialization
    void Start ()
    {
        skillDescription = transform.GetChild(1).GetComponent<Text>();
        skillName = transform.GetChild(0).GetComponent<Text>();
        holder = transform.parent.parent.parent.gameObject;
        playerTransform = holder.GetComponent<Transform>();
        scrollSkill = holder.GetComponent<PlayerScrollSkill>();

        //this.gameObject.transform.localPosition = Camera.main.WorldToScreenPoint(new Vector3(playerTransform.position.x - xOffset, playerTransform.position.y - yOffset, playerTransform.position.z));
        this.gameObject.transform.position = new Vector3(this.transform.parent.parent.parent.position.x, this.transform.parent.parent.parent.position.y + yOffset, this.transform.parent.parent.parent.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        skillName.text = holder.GetComponent<PlayerVariableManager>().skillHolder[scrollSkill.skillSelected].GetComponent<SkillDetail>().skillName;
        skillDescription.text = holder.GetComponent<PlayerVariableManager>().skillHolder[scrollSkill.skillSelected].GetComponent<SkillDetail>().skillDescription;
	}
}