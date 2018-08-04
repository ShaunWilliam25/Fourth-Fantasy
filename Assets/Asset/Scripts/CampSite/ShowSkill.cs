using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowSkill : MonoBehaviour {

    public List<UpgradeElement> player;
    CampsiteManager csm;

    private void Start()
    {
        csm = this.GetComponent<CampsiteManager>();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < player[i].skillImage.Count; j++)
            {
                player[i].skillImage[j].sprite = csm.playerList[i].GetComponent<PlayerVariableManager>().skillList[j].GetComponent<SpriteRenderer>().sprite;
            }
        }
    }
}

[Serializable]
public struct UpgradeElement
{
    public List<Image> skillImage;
}
