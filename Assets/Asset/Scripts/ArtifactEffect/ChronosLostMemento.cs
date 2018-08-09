using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronosLostMemento : ArtifactEffect
{
    [SerializeField]private bool hpHeal = false;

    public void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public override void Artifact()
    {
        if(carrier.GetComponent<PlayerStats>().name == "TimePriestess")
        {
            if (!isEffect)
            {
                carrier.GetComponent<PlayerStats>().baseHealth += 300;
                carrier.GetComponent<PlayerStats>().health = carrier.GetComponent<PlayerStats>().baseHealth;
                isEffect = true;
                hpHeal = false;
            }
            if (!hpHeal && (carrier.GetComponent<PlayerStats>().health / carrier.GetComponent<PlayerStats>().baseHealth) <= 0.1f)
            {
                List<GameObject> playerList = new List<GameObject>();
                playerList = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().playerList;
                for (int i = 0; i < playerList.Count; i++)
                {
                    playerList[i].GetComponent<PlayerTakeDamage>().PlayerHeal((int)(playerList[i].GetComponent<PlayerStats>().baseHealth - playerList[i].GetComponent<PlayerStats>().health));
                }
                hpHeal = true;
            }
        }

        
    }
}
