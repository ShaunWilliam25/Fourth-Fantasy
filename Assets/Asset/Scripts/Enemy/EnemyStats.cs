using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : GeneralStats {

    public int index;
    public int position;


    void Update()
    {
        if (health >= baseHealth)
        {
            health = baseHealth;
        }
        if(health<=0)
        {
            this.GetComponent<EnemyVariableManager>().anim.Play(this.GetComponent<EnemyVariableManager>().deathAnimation);
        }
    }
}
