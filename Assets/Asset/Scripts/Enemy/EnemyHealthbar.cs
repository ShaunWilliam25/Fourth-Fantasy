using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : EnemyVariableManager {
    public float yOffset;
    [SerializeField] private Image hpFrame;


    void Start()
    {
        Transform selfPosition;
        selfPosition = this.GetComponent<Transform>();
        this.GetComponent<EnemyVariableManager>().healthBarBackground.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
        this.GetComponent<EnemyVariableManager>().healthBar.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
        hpFrame.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
    }

    void Update()
    {
        //this.GetComponent<EnemyVariableManager>().healthBarBackground.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
        this.GetComponent<EnemyVariableManager>().healthInPercentage = this.GetComponent<EnemyVariableManager>().enemyStats.health / this.GetComponent<EnemyVariableManager>().enemyStats.baseHealth;

        this.GetComponent<EnemyVariableManager>().healthBar.fillAmount = this.GetComponent<EnemyVariableManager>().healthInPercentage;
    }
}
