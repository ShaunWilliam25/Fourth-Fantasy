using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientBookOfIntelligence : ArtifactEffect {

    public override void Artifact()
    {
        if(isEffect == false)
        {
            carrier.GetComponent<PlayerStats>().baseHealth += 100;
            isEffect = true;
        }
    }
}
