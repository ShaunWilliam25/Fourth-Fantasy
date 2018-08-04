using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CampsiteStatus : MonoBehaviour
{
    CampsiteManager csm;
    public StatusCheckContent player1;
    public StatusCheckContent player2;

    void Start()
    {
        csm = this.GetComponent<CampsiteManager>();
        player1.health.text = "Health : " + csm.playerList[0].GetComponent<PlayerStats>().health.ToString();
        player2.health.text = "Health : " + csm.playerList[1].GetComponent<PlayerStats>().health.ToString();
        for (int i=0;i<csm.playerList[0].GetComponent<PlayerVariableManager>().artifactsList.Count;i++)
        {
            player1.artifact[i].artifactName.text = csm.playerList[0].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().name;
            player1.artifact[i].artifactEffect.text = csm.playerList[0].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().effect;
            player1.artifact[i].artifactImage.sprite = csm.playerList[0].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().sprite;
        }
        for (int i = 0; i < csm.playerList[1].GetComponent<PlayerVariableManager>().artifactsList.Count; i++)
        {
            player2.artifact[i].artifactName.text = csm.playerList[1].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().name;
            player2.artifact[i].artifactEffect.text = csm.playerList[1].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().effect;
            player2.artifact[i].artifactImage.sprite = csm.playerList[1].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().sprite;
        }
    }

    private void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            player1.skill[i].skillName.text = csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SkillDetail>().skillName;
            player1.skill[i].skillEffect.text = csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SkillDetail>().skillDescription;
            player1.skill[i].skillImage.sprite = csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SpriteRenderer>().sprite;
            for(int j = 0; j < csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SkillDetail>().upgradedCount; j++ )
            {
                player1.skill[i].AddOnEffect[j].text = csm.playerList[0].GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SkillDetail>().upgradedEffect[j];
            }
        }
        for (int i = 0; i < 5; i++)
        {
            player2.skill[i].skillName.text = csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SkillDetail>().skillName;
            player2.skill[i].skillEffect.text = csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SkillDetail>().skillDescription;
            player2.skill[i].skillImage.sprite = csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SpriteRenderer>().sprite;
            for (int j = 0; j < csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SkillDetail>().upgradedCount + 1; j++)
            {
                player2.skill[i].AddOnEffect[j].text = csm.playerList[1].GetComponent<PlayerVariableManager>().skillHolder[i].GetComponent<SkillDetail>().upgradedEffect[j];
            }
        }
    }
}

[Serializable]
public struct ArtifactContent
{
    public Text artifactName;
    public Text artifactEffect;
    public Image artifactImage;
}

[Serializable]
public class SkillContent
{
    public Image skillImage;
    public Text skillName;
    public Text skillEffect;
    public Text[] AddOnEffect = new Text[3];
}

[Serializable]
public class StatusCheckContent
{
    public ArtifactContent[] artifact = new ArtifactContent[5];
    public SkillContent[] skill = new SkillContent[5];
    public Text health;
}
