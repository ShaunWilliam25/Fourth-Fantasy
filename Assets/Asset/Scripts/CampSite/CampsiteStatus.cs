using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CampsiteStatus : MonoBehaviour
{
    CampsiteManager csm;
    public Text p1health;
    public Text p2health;
    public ArtifactContent[] player1 = new ArtifactContent[5];
    public ArtifactContent[] player2 = new ArtifactContent[5];

    void Start()
    {
        csm = this.GetComponent<CampsiteManager>();
        p1health.text = "Health : " + csm.playerList[0].GetComponent<PlayerStats>().health.ToString();
        p2health.text = "Health : " + csm.playerList[1].GetComponent<PlayerStats>().health.ToString();
        for (int i=0;i<csm.playerList[0].GetComponent<PlayerVariableManager>().artifactsList.Count;i++)
        {
            player1[i].artifactName.text = csm.playerList[0].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().name;
            player1[i].artifactEffect.text = csm.playerList[0].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().effect;
            player1[i].artifactImage.sprite = csm.playerList[0].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().sprite;
        }
        for (int i = 0; i < csm.playerList[1].GetComponent<PlayerVariableManager>().artifactsList.Count; i++)
        {
            player2[i].artifactName.text = csm.playerList[1].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().name;
            player2[i].artifactEffect.text = csm.playerList[1].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().effect;
            player2[i].artifactImage.sprite = csm.playerList[1].GetComponent<PlayerVariableManager>().artifactsList[i].GetComponent<ArtifactInformation>().sprite;
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
