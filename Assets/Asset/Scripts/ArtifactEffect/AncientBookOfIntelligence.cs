using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientBookOfIntelligence : ArtifactEffect {

    public void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public override void Artifact()
    {
        if(!isEffect)
        {
            carrier.GetComponent<PlayerStats>().baseHealth += 100;
            carrier.GetComponent<PlayerStats>().health = carrier.GetComponent<PlayerStats>().baseHealth;
            isEffect = true;
        }
    }
}
