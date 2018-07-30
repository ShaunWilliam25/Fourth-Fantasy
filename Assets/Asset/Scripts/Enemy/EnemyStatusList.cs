using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatusList : EnemyVariableManager
{
    public List<Sprite> statusIcon;
    public List<Image> statusesList = new List<Image>();
    public Sprite Empty;
    
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            statusesList[i].sprite = Empty;
        }

        if (statusIcon.Count >0)
        {
            for (int i = 0; i < statusIcon.Count; i++)
            {
                statusesList[i % 5].sprite = statusIcon[i];
            }
        }
    }
}
