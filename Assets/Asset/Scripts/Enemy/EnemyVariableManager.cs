using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyVariableManager : MonoBehaviour {

    //! Enemy Action Time Bar Variable
    [Header("Enemy Action Timer Bar")]
    public float curCooldown;
    public float maxCooldown;
    public Image actionBar;
    public bool ATBFull = false;
    public Text skillText;
    public Animator anim;

    //!Enemy Animation Controller
    //[Header("Enemy Animation Controller")]
    public string idleAnimation;
    public string attackAnimation;

    //! Enemy Status List
    [Header("Enemy Status Effect List")]
    public List<GameObject> statusList;
    //! Enemy Stats
    [Header("Enemy Stats")]
    public EnemyStats enemyStats;

    //! Enemy Health Bar
    [Header("Enemy Health Bar")]
    public Image healthBar;
    public Image healthBarBackground;
    public float healthInPercentage;

    //! Enemy Choose Target
    [Header("Enemy Choose Target")]
    public List<GameObject> playerList;
    public bool isTargetChosen = false;
    public bool isSkillUsed = false;
    public GameObject hiAggroTarget;
    public GameObject loAggroTarget;
    public int randNum;
    public GameObject Target;
    //public SceneManager SceneManager;
    public GameObject aimIcon;
    public Vector2 aimIconPosition;

    //! Enemy Choose Skill
    [Header("Enemy Choose Skill")]
    public int randNo;
    //public enemyTarget eT;
    public List<GameObject> enemyList;
    public bool UltiUsed = false;
    public bool canUseUlti = false;
    public List<GameObject> skillsPrefab;
    public List<GameObject> skillList;
    public List<int> skillPercentageUpperLimit;
    public GameObject skillToUse;

    //! Enemy Execute Skill
    [Header("Enemy Execute Skill")]
    public int something;

    public battleLog battlelogScript;

    //! Audio
    [Header("Audio")]
    public AudioManager audioManager;

    private void Awake()
    {
        enemyStats = this.GetComponent<EnemyStats>();
        playerList = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>().playerList;
        battlelogScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<battleLog>();

        if (this.gameObject.tag == "spiritdoor")
        {
            idleAnimation = "SpiritDoorIdleAnimation";
            attackAnimation = "SpiritDoorAttackAnimation";
        }
        else if (this.gameObject.tag == "wolf")
        {
            idleAnimation = "wolfIdleAnimation";
            attackAnimation = "WolfAttackAnim1";
        }
        else if (this.gameObject.tag == "swordskeleton")
        {
            idleAnimation = "SkeletonSwordIdleAnim";
            attackAnimation = "skeletonSwordAtack";
        }
        else if (this.gameObject.tag == "greedboss")
        {
            idleAnimation = "GreedBossIdleAnimation";
            attackAnimation = "GreedBossAttackAnimation";
        }
    }
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

}
