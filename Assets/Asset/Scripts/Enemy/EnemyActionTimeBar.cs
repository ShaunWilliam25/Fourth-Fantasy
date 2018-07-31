using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyActionTimeBar : EnemyVariableManager {
    public float yOffset;
    // Use this for initialization
    void Start ()
    {
        this.GetComponent<EnemyVariableManager>().maxCooldown = 4;
        this.GetComponent<EnemyVariableManager>().maxPauseTime = 1;
        this.GetComponent<EnemyVariableManager>().actionBar.fillAmount = 0;
        this.GetComponent<EnemyVariableManager>().curCooldown = 0;
        Transform selfPosition;
        selfPosition = this.GetComponent<Transform>();
        //this.GetComponent<EnemyVariableManager>().actionBar.transform.localPosition = Camera.main.WorldToScreenPoint(new Vector3(selfPosition.position.x - 6.35f, selfPosition.position.y - 1.8f, selfPosition.position.z));
        this.GetComponent<EnemyVariableManager>().actionBar.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateBar();
    }

    void UpdateBar()
    {
        //this.GetComponent<EnemyVariableManager>().actionBar.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
        if (!ATBFull)
        {
            this.GetComponent<EnemyVariableManager>().curCooldown += Time.deltaTime;
            this.GetComponent<EnemyVariableManager>().actionBar.fillAmount = this.GetComponent<EnemyVariableManager>().curCooldown/this.GetComponent<EnemyVariableManager>().maxCooldown;

            ///this.GetComponent<EnemyVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<EnemyVariableManager>().attackAnimation);
            ///Invoke("ResetAnimation", 1f);

            ///Debug.Log("attack anim");

            if (this.GetComponent<EnemyVariableManager>().curCooldown >= this.GetComponent<EnemyVariableManager>().maxCooldown)
            {
                this.GetComponent<EnemyVariableManager>().pauseTime += Time.deltaTime;
                //this.GetComponent<EnemyVariableManager>().skillText.text = "using skill 1";
                if (this.GetComponent<EnemyVariableManager>().pauseTime >= this.GetComponent<EnemyVariableManager>().maxPauseTime)
                {
                    //curCooldown = 0;
                    this.GetComponent<EnemyVariableManager>().pauseTime = 0;
                    this.GetComponent<EnemyVariableManager>().ATBFull = true;
                    //this.GetComponent<EnemyVariableManager>().skillText.text = "                   ";
                }

                //this.GetComponent<EnemyVariableManager>().ATBFull = true;
                //this.GetComponent<EnemyVariableManager>().curCooldown = 0;
            }
        }
        /*if (!ATBFull)
        {
            curCooldown += Time.deltaTime * this.GetComponent<EnemyStats>().speed / 100;
            actionBar.fillAmount = curCooldown;
            if (curCooldown >= maxCooldown)
            {
                pauseTime += Time.deltaTime;
                showText();
                if (pauseTime >= maxPauseTime)
                {
                    curCooldown = 0;
                    pauseTime = 0;
                    ATBFull = true;
                    skillText.text = "                   ";
                }

            }
        }*/
    }

    /*   void ResetAnimation()
       {
           this.GetComponent<EnemyVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<EnemyVariableManager>().idleAnimation);
           Debug.Log("idle anim");
       }*/
}
