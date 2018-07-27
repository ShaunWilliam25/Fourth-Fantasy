using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBook : ArtifactEffect
{
    public void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public override void Artifact()
    {
        if (!isEffect)
        {
            carrier.GetComponent<PlayerStats>().magic += (int)(carrier.GetComponent<PlayerStats>().baseMagic * 0.3f);
            isEffect = true;
        }
    }

}
