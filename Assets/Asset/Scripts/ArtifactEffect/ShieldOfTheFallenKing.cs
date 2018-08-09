using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOfTheFallenKing : ArtifactEffect {

    public int damageCount = 0;

    public void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public override void Artifact()
    {
        if(!isEffect && carrier.GetComponent<PlayerStats>().name == "OldGuard")
        {
            carrier.GetComponent<PlayerStats>().baseHealth += 500;
            carrier.GetComponent<PlayerStats>().health = carrier.GetComponent<PlayerStats>().baseHealth;
            damageCount = 0;
            isEffect = true;
        }
    }
}
