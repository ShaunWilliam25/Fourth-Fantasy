using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBook : ArtifactEffect
{
    public void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public override void Artifact()
    {
        if(!isEffect)
        {
            carrier.GetComponent<PlayerStats>().strength += (int)(carrier.GetComponent<PlayerStats>().baseStrength * 0.3f);
            isEffect = true;
        }
    }

}
