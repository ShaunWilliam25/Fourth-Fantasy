using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBook : ArtifactEffect
{
    public void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public override void Artifact()
    {
        if (!isEffect)
        {
            carrier.GetComponent<PlayerStats>().spirit += (int)(carrier.GetComponent<PlayerStats>().baseSpirit * 0.3f);
            isEffect = true;
        }
    }

}
