using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillUpgrade : MonoBehaviour {

    public bool upgraded = false;
    public float holdTimer = 0;
    public float timeNeeded = 1;
    

    public enum UpgradeState
    {
        CHOOSE_SKILL = 0,
        CHOOSE_UPGRADE,
        VALIDATE_UPGRADE,
        UPGRADE
    }

    public GameObject skillToUpgrade;

    void Update()
    {
        if(Input.GetKey("a"))
        {
            holdTimer += Time.deltaTime;
            if(holdTimer >= timeNeeded)
            {
                
            }
        }
    }

}
