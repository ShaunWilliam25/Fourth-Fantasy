using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBook : ArtifactEffect
{
    public void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public override void Artifact()
    {
        if (!isEffect)
        {
            carrier.GetComponent<PlayerStats>().defense += (int)(carrier.GetComponent<PlayerStats>().baseDefense * 0.3f);
            isEffect = true;
        }
    }

}
