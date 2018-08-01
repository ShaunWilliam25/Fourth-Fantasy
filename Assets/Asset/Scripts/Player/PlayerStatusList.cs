using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusList : PlayerVariableManager {
    public List<Sprite> statusIcon;
    public List<Image> statusesList;
    public Sprite Empty;
    public float swapTimer;
	
	void Update ()
    {
        swapTimer += Time.deltaTime;
        for(int i=0;i<5;i++)
        {
            statusesList[i].sprite = Empty;
        }
        
        if (statusIcon != null)
        {
            /*for (int i = 0; i < statusIcon.Count; i++)
            {
                statusesList[i%5].sprite = statusIcon[i];
            }*/
            if(statusIcon.Count > 5)
            {
                if(swapTimer%1 < 0.5f)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        statusesList[i%5].sprite = statusIcon[i];
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        statusesList[i % 5].sprite = statusIcon[i+5];
                    }
                }
            }
        }
	}
}
