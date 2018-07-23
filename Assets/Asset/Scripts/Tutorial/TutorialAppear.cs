using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialAppear : MonoBehaviour {

    public EventSystem eventSystem;
    public TUTORIAL_STAGE tutorialStage;
    public Text task;
    public Toggle player1;
    public Toggle player2;
    public Canvas taskCanvas;
    public Canvas lectureCanvas;
    public GameObject tint;
    [SerializeField] SceneManager sceneManager;
    [SerializeField] List<actionTimeBar> playerAtbList;
    bool isLectureDone = false;
    bool isOrderLayerAdjusted = false;
    bool isLecture6ShowedBefore = false;
    public bool isEnemyAttacked = false;

    public enum TUTORIAL_STAGE
    {
        STAGE_01 = 0,
        STAGE_02,
        STAGE_03,
        STAGE_04,
        STAGE_05,
        STAGE_06,
        STAGE_07,
        STAGE_08,
        STAGE_09,
        THE_END
    }

    private void Awake()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
    }

    // Use this for initialization
    void Start ()
    {
        //eventSystem.SetSelectedGameObject(exit);
        tutorialStage = TUTORIAL_STAGE.STAGE_01;
        for (int i = 0; i < sceneManager.playerList.Count; i++)
        {
            playerAtbList.Add(sceneManager.playerList[i].GetComponent<actionTimeBar>());
        }
    }

    private void OnEnable()
    {
        //Time.timeScale = 0;
        //eventSystem.SetSelectedGameObject(exit);
    }

    private void OnDisable()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (tutorialStage == TUTORIAL_STAGE.STAGE_01)
        {
            //! The black tint that covers up things that are not necessary
            tint.SetActive(true);
            if(!isOrderLayerAdjusted)
            {
                for(int i=0;i<sceneManager.playerList.Count;i++)
                {
                    //! Skill Description order
                    sceneManager.playerList[i].transform.GetChild(2).GetChild(1).GetComponent<Canvas>().sortingOrder = 3;
                    sceneManager.playerList[i].transform.GetChild(2).GetChild(0).GetComponent<Canvas>().sortingOrder = 0;
                }
                isOrderLayerAdjusted = true;
            }

            task.text = "Tap your key (A or L) to scroll through your moves. Scroll through at least 3 moves on each character to continue.";
            if(lectureCanvas.transform.GetChild(0).gameObject.activeInHierarchy == false)
            {
                lectureCanvas.transform.GetChild(0).gameObject.SetActive(true);
            }            
        }
        else if (tutorialStage == TUTORIAL_STAGE.STAGE_02)
        {
            //! The black tint that covers up things that are not necessary
            tint.SetActive(true);
            isOrderLayerAdjusted = false;
            if (!isOrderLayerAdjusted)
            {
                Debug.Log(isOrderLayerAdjusted);
                for (int i = 0; i < sceneManager.playerList.Count; i++)
                {
                    //! Skill Description order
                    sceneManager.playerList[i].transform.GetChild(2).GetChild(0).GetComponent<Canvas>().sortingOrder = 3;
                    sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 3;
                }
                for(int i=0;i<sceneManager.enemyList.Count;i++)
                {
                    sceneManager.enemyList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 3;
                    sceneManager.enemyList[i].transform.GetChild(2).GetChild(0).GetComponent<Canvas>().sortingOrder = 3;                    
                }
                isOrderLayerAdjusted = true;
            }

            //! The lecture canvas 
            lectureCanvas.transform.GetChild(0).gameObject.SetActive(false);
            if (!isLectureDone)
            {
                if (playerAtbList[0].startSelection >= 0.5f || playerAtbList[1].startSelection >= 0.5f)
                {
                    Time.timeScale = 0;
                    lectureCanvas.transform.GetChild(1).gameObject.SetActive(true);

                    if (Input.anyKeyDown)
                    {
                        Time.timeScale = 1;
                        isLectureDone = true;
                        lectureCanvas.transform.GetChild(1).gameObject.SetActive(false);
                    }
                }
            }                       
            task.text = "Select normal attack and wait for action time bar to finish recharge ";
        }
        else if (tutorialStage == TUTORIAL_STAGE.STAGE_03)
        {
            //! The black tint that covers up things that are not necessary
            tint.SetActive(true);
            isOrderLayerAdjusted = false;
            if (!isOrderLayerAdjusted)
            {
                Debug.Log(isOrderLayerAdjusted);
                for (int i = 0; i < sceneManager.playerList.Count; i++)
                {
                    //! Skill Description order
                    sceneManager.playerList[i].transform.GetChild(2).GetChild(0).GetComponent<Canvas>().sortingOrder = 0;
                    sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 0;
                    sceneManager.playerList[i].transform.GetChild(1).gameObject.SetActive(false);
                    sceneManager.playerList[i].transform.GetChild(2).GetChild(1).GetComponent<Canvas>().sortingOrder = 0;
                }
                for (int i = 0; i < sceneManager.enemyList.Count; i++)
                {
                    sceneManager.enemyList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 0;
                    sceneManager.enemyList[i].transform.GetChild(2).GetChild(0).GetComponent<Canvas>().sortingOrder = 0;
                }
                isOrderLayerAdjusted = true;
            }


            //! Task canvas
            taskCanvas.enabled = false;

            //! Lecture Canvas
            isLectureDone = false;
            if (!isLectureDone)
            {
                Time.timeScale = 0;
                lectureCanvas.transform.GetChild(2).gameObject.SetActive(true);

                if (Input.anyKeyDown)
                {
                    Time.timeScale = 1;
                    isLectureDone = true;
                    lectureCanvas.transform.GetChild(2).gameObject.SetActive(false);
                    tutorialStage = TUTORIAL_STAGE.STAGE_04;
                }
            }         
        }
        else if(tutorialStage == TUTORIAL_STAGE.STAGE_04)
        {
            if(tint.activeInHierarchy == false)
            {
                tint.SetActive(true);
            }

            isLectureDone = false;
            if (!isLectureDone)
            {
                Time.timeScale = 0;
                lectureCanvas.transform.GetChild(3).gameObject.SetActive(true);

                if (Input.anyKeyDown)
                {
                    Time.timeScale = 1;
                    isLectureDone = true;
                    lectureCanvas.transform.GetChild(3).gameObject.SetActive(false);
                    tutorialStage = TUTORIAL_STAGE.STAGE_05;
                }
            }
        }

        else if(tutorialStage == TUTORIAL_STAGE.STAGE_05)
        {
            if (tint.activeInHierarchy == false)
            {
                tint.SetActive(true);
            }

            for (int i = 0; i < sceneManager.enemyList.Count; i++)
            {
                sceneManager.enemyList[i].GetComponent<EnemyVariableManager>().aimIcon.SetActive(true);
                sceneManager.enemyList[i].transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 4;
                sceneManager.enemyList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 3;
                sceneManager.enemyList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                if(sceneManager.enemyList[i].GetComponent<EnemyVariableManager>().Target == sceneManager.playerList[0])
                {
                    lectureCanvas.transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
                }
                else if (sceneManager.enemyList[i].GetComponent<EnemyVariableManager>().Target == sceneManager.playerList[1])
                {
                    lectureCanvas.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                }
            }
            for (int i = 0; i < sceneManager.playerList.Count; i++)
            {
                //! Skill Description order
                sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            isLectureDone = false;
            if (!isLectureDone)
            {
                Time.timeScale = 0;
                lectureCanvas.transform.GetChild(4).gameObject.SetActive(true);

                if (Input.anyKeyDown)
                {
                    Time.timeScale = 1;
                    isLectureDone = true;
                    lectureCanvas.transform.GetChild(4).gameObject.SetActive(false);
                    tutorialStage = TUTORIAL_STAGE.STAGE_06;
                }
            }
        }
        else if(tutorialStage == TUTORIAL_STAGE.STAGE_06)
        {
            if (tint.activeInHierarchy == false)
            {
                tint.SetActive(true);
            }

            for (int i = 0; i < sceneManager.enemyList.Count; i++)
            {
                sceneManager.enemyList[i].GetComponent<EnemyActionTimeBar>().enabled = true;
                sceneManager.enemyList[i].transform.GetChild(2).GetChild(0).GetComponent<Canvas>().sortingOrder = 3;
                sceneManager.enemyList[i].transform.GetChild(2).GetChild(1).GetComponent<Canvas>().sortingOrder = 3;
            }
            for (int i = 0; i < sceneManager.playerList.Count; i++)
            {
                sceneManager.playerList[i].transform.GetChild(2).GetChild(2).GetComponent<Canvas>().sortingOrder = 3;
            }
            
            isLectureDone = false;
            if (!isLecture6ShowedBefore)
            {
                for (int i = 0; i < playerAtbList.Count; i++)
                {
                    if (playerAtbList[i].enabled != false)
                    {
                        playerAtbList[i].enabled = false;
                    }
                }
                for (int i = 0; i < sceneManager.enemyList.Count; i++)
                {
                    if (sceneManager.enemyList[i].GetComponent<EnemyVariableManager>().curCooldown >= 0.5f)
                    {
                        if (!isLectureDone)
                        {
                            Time.timeScale = 0;
                            lectureCanvas.transform.GetChild(5).gameObject.SetActive(true);
                            isLecture6ShowedBefore = true;
                        }
                    }
                }
            }            
            if(!isLectureDone)
            {
                if (Input.anyKeyDown)
                {
                    Time.timeScale = 1;
                    isLectureDone = true;
                    lectureCanvas.transform.GetChild(5).gameObject.SetActive(false);
                }
            }            
            if (isEnemyAttacked)
            {
                taskCanvas.enabled = true;
                task.text = "Kill the Spirit Door";
                for (int i = 0; i < sceneManager.playerList.Count; i++)
                {
                    sceneManager.playerList[i].transform.GetChild(1).gameObject.SetActive(true);
                    sceneManager.playerList[i].transform.GetChild(2).GetChild(0).GetComponent<Canvas>().sortingOrder = 3;
                }
                for (int i = 0; i < playerAtbList.Count; i++)
                {
                    if (playerAtbList[i].enabled != true)
                    {
                        playerAtbList[i].enabled = true;
                    }
                }
                tint.SetActive(false);
            }
        }
        if(tutorialStage == TUTORIAL_STAGE.THE_END)
        {
            Time.timeScale = 0;
            lectureCanvas.transform.GetChild(6).gameObject.SetActive(true);
            tint.SetActive(true);
            taskCanvas.enabled = false;
            for (int i = 0; i < sceneManager.playerList.Count; i++)
            {
                sceneManager.playerList[i].transform.GetChild(1).gameObject.SetActive(false);
                sceneManager.playerList[i].transform.GetChild(2).GetChild(0).GetComponent<Canvas>().sortingOrder = 0;
                sceneManager.playerList[i].transform.GetChild(2).GetChild(2).GetComponent<Canvas>().sortingOrder = 0;
                sceneManager.playerList[i].transform.GetChild(2).GetChild(3).GetComponent<Canvas>().sortingOrder = 0;
                sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                UnityEngine.SceneManagement.SceneManager.LoadScene(6);
            }
        }
    }
}
