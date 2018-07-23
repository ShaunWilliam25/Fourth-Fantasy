using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBook : ArtifactEffect
{
    public override void Artifact()
    {
        if (!isEffect)
        {
            carrier.GetComponent<PlayerStats>().spirit += (int)(carrier.GetComponent<PlayerStats>().baseSpirit * 0.3f);
            isEffect = true;
        }
    }

}
