using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVariableManager : MonoBehaviour {

    //!Player Status List
    [Header("Player Status List")]
    public List<GameObject> statusList;

    //! Player Stats
    [Header("Player Stats List")]
    public PlayerStats playerStats;

    //! Player Scroll Skill
    [Header("Player Scroll Skill")]
    public string playerButton;
    public GameObject tempSkill;
    public Character_Skill_List skillListScript;
    public float offset;

    //! Character Skill List
    [Header("Character Skill List")]
    public List<GameObject> skillList;
    public List<GameObject> skillHolder;

    //! Player Lock In Skill
    /*[Header("Player Lock In Skill")]
    //public BattleStateManager battleStateManager;
    public GameObject lockInSkill;
    //public List<GameObject> skillList;
    //public string playerButton;
    public float holdTimer;
    public float timeNeeded;
    public bool isSkillLockedIn;
    public float lockedInTimer;
    public Image chooseSkillBar;
    public float holdTimerInPercentage;
    public bool isPerfectTiming;
    public Transform playerTransform;
    public float barXOffset;
    public float barYOffset;*/

    //! Player Skill Execution
    [Header("Player Skill Execution")]
    public actionTimeBar actionTimerBarScript;
    public GameObject testSkill;
    public GameObject testEnemy;
    public Color oriColor;
    public Animator anim;
    public battleLog battleLogScript;
    public Transform allySpawnPoint;

    //! Player Skill Choose Target
    [Header("Player Skill Choose Target")]
    public List<Transform> playerTargetCursorPoints;
    public List<Transform> enemyTargetCursorPoints;
    public Enemy_Spawn enemySpawnScript;
    public Player_Spawn playerSpawnScript;
    public SceneManager sceneManagerScript;
    public BattleStateManager battleStateManagerScript;
    public GameObject targetCursor;
    public int cursorIndex;
    public float chooseTargetHoldTimer;
    public float chooseTargetTimeNeeded;
    public GameObject targetedEnemy;
    public GameObject targetCursorBar;
    public float chooseTargetHoldTimerInPercentage;
    public bool isTargetLockedIn;
    public bool isEffectTargetLockedIn = false;

    //!Player Animation Controller
    [Header("Player Animation Controller")]
    public string idleAnimation;
    public string attackAnimation;

    //! Battle State Manager
    [Header("Battle State Manager")]
    public BattleStateManager.GAMESTATE gameState;

    //! Player Artifact Effect
    public List<GameObject> artifactsList;

    private void Awake()
    {
        playerStats = this.GetComponent<PlayerStats>();
        battleStateManagerScript = this.GetComponent<BattleStateManager>();
        /*enemySpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Enemy_Spawn>();
        playerSpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Player_Spawn>();
        sceneManagerScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();        
        battleLogScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<battleLog>();*/
        if (this.gameObject.tag == "Player1")
        {
            playerButton = "P1_Button";
        }
        else if (this.gameObject.tag == "Player2")
        {
            playerButton = "P2_Button";
        }
        skillListScript = this.GetComponent<Character_Skill_List>();

        offset = 1.23f;
        /*timeNeeded = 0.5f;
        isSkillLockedIn = false;
        lockedInTimer = 0f;
        isPerfectTiming = false;*/
        isTargetLockedIn = false;
        //actionTimerBarScript = 

        gameState = BattleStateManager.GAMESTATE.CHOOSING_SKILL;

        if (this.gameObject.tag == "Player1")
        {
            this.GetComponent<PlayerVariableManager>().idleAnimation = "ExiledDemonIdleAnimation";
            this.GetComponent<PlayerVariableManager>().attackAnimation = "ExiledDemonAttackAnimation";
            allySpawnPoint = GameObject.FindGameObjectWithTag("Player2").transform;
        }
        else if (this.gameObject.tag == "Player2")
        {
            this.GetComponent<PlayerVariableManager>().idleAnimation = "TimePriestressIdleAnimation";
            this.GetComponent<PlayerVariableManager>().attackAnimation = "TimePriestressAttackAnimation";
            allySpawnPoint = GameObject.FindGameObjectWithTag("Player1").transform;
        }               
    }
    private void Start()
    {
    }
    private void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        for (int i = 0; i < artifactsList.Count; i++)
        {
            artifactsList[i].GetComponent<SpriteRenderer>().enabled = false;
        }
=======
        
>>>>>>> parent of a49211c... sprite health
=======
        /*for (int i = 0; i < artifactsList.Count; i++)
        {
            artifactsList[i].GetComponent<SpriteRenderer>().enabled = false;
        }*/
>>>>>>> parent of 21a57f7... added desc for needgreed
    }
}
