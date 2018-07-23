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
    public float xOffset = 6.3f;
    public float yOffset = 2.3f;


    // Use this for initialization
    void Start()
    {
        maxHealth = this.GetComponent<PlayerStats>().baseHealth;
        //reset health
        currentHealth = this.GetComponent<PlayerStats>().health;
        healthInPercentage = currentHealth / maxHealth;
        //healthBar.value=calHealth();

        Transform healthBarPosition;
        healthBarPosition = this.GetComponent<Transform>();
        //healthBar.transform.localPosition = Camera.main.WorldToScreenPoint(new Vector3(healthBarPosition.position.x - xOffset, healthBarPosition.position.y - yOffset, healthBarPosition.position.z));       
        healthBarBackground.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {        
        currentHealth = this.GetComponent<PlayerStats>().health;

        healthInPercentage = currentHealth / maxHealth;

        healthBar.fillAmount = healthInPercentage;

    }

}