using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpDamageController : MonoBehaviour {

    private Text damageText;
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, 5f * 0.5f * Time.deltaTime);
	}

    public void SetText(string text,Color colour)
    {
        damageText = GetComponentInChildren<Text>();
        damageText.text = text;
        damageText.color = colour;
    }
}
