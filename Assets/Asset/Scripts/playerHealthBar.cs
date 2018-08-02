using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthBar : MonoBehaviour
{
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public Image healthBar;
    public Image healthBarBackground;
    public float healthInPercentage;
    
    void Start()
    {
        maxHealth = this.GetComponent<PlayerStats>().baseHealth;
        //reset health
        currentHealth = this.GetComponent<PlayerStats>().health;
        healthInPercentage = currentHealth / maxHealth;
        //healthBar.value=calHealth()
    }

    // Update is called once per frame
    void Update()
    {        
        currentHealth = this.GetComponent<PlayerStats>().health;

        healthInPercentage = currentHealth / maxHealth;

        healthBar.fillAmount = healthInPercentage;

    }

}