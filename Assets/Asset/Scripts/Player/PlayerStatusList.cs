using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusList : PlayerVariableManager {
    public List<Sprite> statusIcon;
    public List<Image> statusesList;
    public Sprite Empty;
	
	void Update ()
    {
        for(int i=0;i<5;i++)
        {
            statusesList[i].sprite = Empty;
        }
        
        if (statusIcon != null)
        {
            for (int i = 0; i < statusIcon.Count; i++)
            {
                statusesList[i%5].sprite = statusIcon[i];
            }
        }
	}
}
