using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartOfTheDemonLord : ArtifactEffect {


    public void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public override void Artifact()
    {
        if (carrier.GetComponent<PlayerStats>().name == "ExiledDemon")
        {
            if (!isEffect)
            {
                carrier.GetComponent<PlayerStats>().baseHealth += 250;
                carrier.GetComponent<PlayerStats>().health = carrier.GetComponent<PlayerStats>().baseHealth;
                carrier.GetComponent<PlayerStats>().autoRevive = true;
                isEffect = true;
            }
        }
        
    }
}
