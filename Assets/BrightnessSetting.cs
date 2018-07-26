using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSetting : MonoBehaviour

{
   public Slider Brightness;
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
}
