using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillUpgrade : MonoBehaviour {
    public enum UpgradeState
    {
        CHOOSE_SKILL = 0,
        CHOOSE_UPGRADE,
        VALIDATE_UPGRADE,
        UPGRADE
    }

    public GameObject skillToUpgrade;    

}
