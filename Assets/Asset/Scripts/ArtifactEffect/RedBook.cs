using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBook : ArtifactEffect
{
    public override void Artifact()
    {
        if(!isEffect)
        {
            carrier.GetComponent<PlayerStats>().strength += (int)(carrier.GetComponent<PlayerStats>().baseStrength * 0.3f);
            isEffect = true;
        }
    }

}
