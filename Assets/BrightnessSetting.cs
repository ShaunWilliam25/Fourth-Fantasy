﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class BrightnessSetting : MonoBehaviour

{
    public float BrightnessCorrection;
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
        tempmodel = myProfile.colorGrading.settings;
        gamemodel = otherProfile.colorGrading.settings;

        if (NewBrightness.instance.isNewGameBrightness)
        {
            /*BrightnessCorrection = 1.25f;
            tempmodel.basic.contrast = BrightnessCorrection;
            gamemodel.basic.contrast = BrightnessCorrection;
            */
            NewBrightness.Instance.brightnessValue = 0.5f;
            tempmodel.basic.contrast = NewBrightness.Instance.brightnessValue;
            gamemodel.basic.contrast = NewBrightness.Instance.brightnessValue;

            NewBrightness.instance.isNewGameBrightness = false;
        }

        slider.onValueChanged.AddListener(delegate { sliderChanged(); });
        //slider.value = PlayerPrefs.GetFloat("BrightnessCorrection");
        slider.value = NewBrightness.Instance.brightnessValue;


    }

    void Update()
    {
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        string SceneName = currentScene.name;

        //tempmodel.basic.contrast = BrightnessCorrection;
        //gamemodel.basic.contrast = BrightnessCorrection;
        NewBrightness.Instance.brightnessValue = slider.value;

        tempmodel.basic.contrast = NewBrightness.Instance.brightnessValue;
        gamemodel.basic.contrast = NewBrightness.Instance.brightnessValue;


        //PlayerPrefs.SetFloat("BrightnessCorrection", slider.value);
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
