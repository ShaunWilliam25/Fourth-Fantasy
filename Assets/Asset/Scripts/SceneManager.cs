using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

    public List<GameObject> playerList;
    public List<GameObject> enemyList;
    private int playerDeathCount = 0;
    public bool isWin = false;
    //public SceneManager BrightnessSetting;
    //public SliderJoint2D BrightnessSlider;
    public GameObject victory;
    public GameObject VictoryGO;
    public int nextScene;
    public float loseTimer;
    public TutorialAppear tutorial;
    public GameObject needGreedManager;
    public GameObject ArtifactSpawner;
    public List<BattleSceneScriptableObject> waveDetails;


    public void Awake()
    {
        tutorial = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TutorialAppear>();
        if (Player1.instance.gameObject.activeInHierarchy == false)
        {
            Player1.instance.gameObject.SetActive(true);
        }
        if (Player2.instance.gameObject.activeInHierarchy == false)
        {
            Player2.instance.gameObject.SetActive(true);
        }
        ArtifactSpawner = artifactSpawnerSingleton.instance.gameObject;
    }


    public void Start()
    {                
        //audioManager = FindObjectOfType<AudioManager>();
        if (AudioManager.instance.soundPlaying.Count > 0)
        {
            for (int i = 0; i < AudioManager.instance.soundPlaying.Count; i++)
            {
                AudioManager.instance.soundPlaying[i].source.Stop();
            }
            AudioManager.instance.soundPlaying.Clear();
        }
        AudioManager.instance.PlaySound("BattleSound");

        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<battleLog>().ShowGui == false)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<battleLog>().ShowGui = true;
        }
        for(int i=0;i<playerList.Count;i++)
        {
            if(playerList[i].GetComponent<actionTimeBar>().enabled == false)
            {
                playerList[i].GetComponent<actionTimeBar>().enabled = true;
            }
        }
    }

    private void Update()
    {
        //! Spawning artifact when enemy is dead
        for (int i=enemyList.Count-1;i>=0;i--)
        {
            if(enemyList[i].GetComponent<EnemyStats>().health <= 0)
            {
                
                for (int j = 0; j < playerList.Count; j++)
                {
                    playerList[j].GetComponent<PlayerVariableManager>().isTargetLockedIn = false;

                }

                enemyList[i].GetComponent<EnemyActionTimeBar>().enabled = false;
                Destroy(enemyList[i],1.3f);

                enemyList.Remove(enemyList[i]);

                if (tutorial.tutorialStage != TutorialAppear.TUTORIAL_STAGE.STAGE_06 && tutorial.tutorialStage != TutorialAppear.TUTORIAL_STAGE.THE_END)
                    ArtifactSpawner.GetComponent<ArtifactScript>().calArtifact();

            }

            
        }

        //! When all enemy is dead,check for win
        if(enemyList.Count <=0)
        {
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

                    //!Check if its the knight battle,to move to the win game scene
                    if(AudioManager.instance.waveIndex == 4)
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                    }

                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<battleLog>().ShowGui = false;
                    VictoryGO = Instantiate(victory);
                    isWin = true;
                }
            }
            
        }

        if (isWin)
        {
            if (Input.anyKeyDown)
            {
                //UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
                needGreedManager.GetComponent<NeedGreedRandomizer>().addArtifactToPlayer();
            }
        }

        //! Test control to check the lose scene
        
        if (Input.GetKeyDown("b"))
        {
            //for (int k = 0; k < playerList.Count; k++)
            //{
                playerList[0].GetComponent<PlayerStats>().health = 0;

            //}
        }

        if (playerList[0].GetComponent<PlayerVariableManager>().playerStats.knockedOut && playerList[1].GetComponent<PlayerVariableManager>().playerStats.knockedOut)
        {
            loseTimer += Time.deltaTime;
            if (loseTimer > 1)
            {
                AudioManager.instance.waveIndex--;
                playerList[0].SetActive(false);
                playerList[1].SetActive(false);
                UnityEngine.SceneManagement.SceneManager.LoadScene(4);
              
            }
        }
    }
}
