using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

    public List<GameObject> playerList;
    public List<GameObject> enemyList;
    private int playerDeathCount = 0;
    private bool isWin = false;
    public AudioManager audioManager;
    public GameObject victory;
    public int nextScene;
    public float loseTimer;
    public TutorialAppear tutorial;

    public void Awake()
    {
        //audioManager.PlaySound("BattleSound");
        tutorial = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TutorialAppear>();
        playerList[0] = GameObject.FindGameObjectWithTag("Player1");
        playerList[1] = GameObject.FindGameObjectWithTag("Player2");
    }
    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager.soundPlaying.Count > 0)
        {
            for (int i = 0; i < audioManager.soundPlaying.Count; i++)
            {
                audioManager.soundPlaying[i].source.Stop();
            }
            audioManager.soundPlaying.Clear();
        }
        audioManager.PlaySound("BattleSound");
    }

    private void Update()
    {
        for (int i=enemyList.Count-1;i>=0;i--)
        {
            if(enemyList[i].GetComponent<EnemyStats>().health <= 0)
            {
                enemyList[i].SetActive(false);
                enemyList.Remove(enemyList[i]);
            }
        }
        if(enemyList.Count <=0)
        {
            Debug.Log("Win");
            if (tutorial.tutorialStage != TutorialAppear.TUTORIAL_STAGE.STAGE_06 && tutorial.tutorialStage != TutorialAppear.TUTORIAL_STAGE.THE_END)
            {
                if (!isWin)
                {
                    Debug.Log("Win");
                    for (int i = 0; i < playerList.Count; i++)
                    {
                        playerList[i].GetComponent<actionTimeBar>().enabled = false;
                        for (int j = 1; j < playerList[i].transform.childCount; j++)
                        {
                            playerList[i].transform.GetChild(j).gameObject.SetActive(false);
                        }
                    }
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<battleLog>().ShowGui = false;
                    Instantiate(victory);
                    isWin = true;
                }
            }
            
        }

        if (isWin)
        {
            if (Input.anyKeyDown)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
            }
        }
        if (Input.GetKeyDown("b"))
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                playerList[i].GetComponent<PlayerStats>().health = 0;
            }
        }

        if (playerList[0].GetComponent<PlayerVariableManager>().playerStats.health <= 0 && playerList[1].GetComponent<PlayerVariableManager>().playerStats.health <= 0)
        {
            loseTimer += Time.deltaTime;
            if (loseTimer > 1)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(4);
            }
        }
    }
}
