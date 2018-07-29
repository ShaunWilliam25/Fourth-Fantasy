using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CampsiteStatus : MonoBehaviour
{

    public Text player1Health;
    public ArtifactContent[] artifactContent = new ArtifactContent[5];

    void Start()
    {
        PlayerPrefs.SetInt("P1 HP", 400);
        PlayerPrefs.SetInt("P1 MAX HP", 450);
        player1Health.text = "Health : " + (PlayerPrefs.GetInt("P1 HP").ToString()) + "/" + (PlayerPrefs.GetInt("P1 MAX HP").ToString());
    }
}

[Serializable]
public struct ArtifactContent
{
    public Text artifactName;
    public Text artifactEffect;
    public Image artifactImage;
}
