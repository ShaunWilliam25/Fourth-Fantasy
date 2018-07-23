using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBook : ArtifactEffect
{
    public override void Artifact()
    {
        if (!isEffect)
        {
            carrier.GetComponent<PlayerStats>().magic += (int)(carrier.GetComponent<PlayerStats>().baseMagic * 0.3f);
            isEffect = true;
        }
    }

}
