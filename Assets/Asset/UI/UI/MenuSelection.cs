using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour {
    public EventSystem eventSystem;
    public Sprite selectedImage;
    public Sprite defaultImage;
    public Sprite chosenImage;
    float timer = 0;
    float duration = 1;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(eventSystem.currentSelectedGameObject == this.gameObject)
        {
            this.GetComponent<Image>().sprite = selectedImage;
        }
        else
        {
            this.GetComponent<Image>().sprite = defaultImage;
        }
	}

    public void Selection()
    {
        this.GetComponent<Image>().sprite = selectedImage;
    }
    public void Deselection()
    {
        this.GetComponent<Image>().sprite = defaultImage;
    }

    public void OnMouseEnter()
    {
        eventSystem.SetSelectedGameObject(this.gameObject);
    }

    public void Click()
    {
        this.GetComponent<Image>().sprite = chosenImage;
        timer += Time.deltaTime;
        if(timer >= duration)
        {
            this.GetComponent<Image>().sprite = defaultImage;
        }

    }

}
