using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class BrightnessSetting : MonoBehaviour

{
    public float BrightnessCorrection = 1f;
    public Slider slider;
    public static BrightnessSetting instance;
    public ColorGradingComponent myColor;
    public PostProcessingProfile myProfile;
    public PostProcessingProfile otherProfile;
    ColorGradingModel.Settings tempmodel;
    ColorGradingModel.Settings gamemodel;
    SceneManager GetActiveScene;

    void Start()
    {
        if(AudioManager.instance.isNewGameBrightness)
        {
            tempmodel = myProfile.colorGrading.settings;
            gamemodel = otherProfile.colorGrading.settings;

            tempmodel.basic.contrast = 1;
            gamemodel.basic.contrast = 1;

            myProfile.colorGrading.settings = tempmodel;
            otherProfile.colorGrading.settings = gamemodel;

            slider.onValueChanged.AddListener(delegate { sliderChanged(); });
            slider.value = PlayerPrefs.GetFloat("BrightnessCorrection");

            //! Set the isNewGame bool to prevent reset when return to main menu
            AudioManager.instance.isNewGameBrightness = false;

        }
    }

    void Update()
    {
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        string SceneName = currentScene.name;

        PlayerPrefs.SetFloat("BrightnessCorrection", slider.value);
    }

    public void sliderChanged()
    {
        BrightnessCorrection = slider.value;

        tempmodel.basic.contrast = BrightnessCorrection;
        gamemodel.basic.contrast = BrightnessCorrection;

        myProfile.colorGrading.settings = tempmodel;
        otherProfile.colorGrading.settings = gamemodel;
    }

}


/*
{
   public Slider BrightnessCorrection;
   float brightness;
   float value = 1f;
   // float ambientDarkest = 1;
   // float ambientLightest = 4;
   // public Vector2 material;


    // Update is called once per frame
    void Update()
    {

        float colorVal = 0.5f;

        {
           
            //colorVal = UnityEngine.UI.Slider(colorVal, 0f, 1.0f);
            RenderSettings.ambientLight = new Color(colorVal, colorVal, colorVal, 1);
        }


       // brightness = Brightness.value;
       // RenderSettings.ambientLight = new Color(0, 0, 0, 2);
       // RenderSettings.ambientIntensity = 5f;

    }

    //void OnRenderImage(RenderTexture source, RenderTexture destination)
       // {
       //     material.SetFloat("_Brightness", brightness);
      //      Graphics.Blit(source, destination, material);
       // }
   // }
}*/
