using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBrightness : MonoBehaviour {
    [SerializeField] Image brightnessImage;
    public static NewBrightness instance;
    public float brightnessValue;
    public bool isNewGameBrightness = true;

    public static NewBrightness Instance
    {
        get
        {
            return instance;
        }

    }

    private void Awake()
    {
        if (instance != null && instance != this.gameObject)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            isNewGameBrightness = true;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		if(isNewGameBrightness)
        {
            brightnessValue = 0.75f;
            isNewGameBrightness = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        brightnessImage.color = new Color(brightnessImage.color.r, brightnessImage.color.g, brightnessImage.color.b,brightnessValue);
	}
}
