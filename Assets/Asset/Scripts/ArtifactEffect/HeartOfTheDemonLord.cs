using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartOfTheDemonLord : ArtifactEffect {

    private bool revive = false;

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
                isEffect = true;
            }
            if (!revive)
            {
                carrier.GetComponent<PlayerStats>().autoRevive = true;
                revive = true;
            }

            if(GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().isWin)
            {
                revive = false;
            }
        }
        
    }
}
