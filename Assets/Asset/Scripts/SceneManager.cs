using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

    public List<GameObject> playerList;
    public List<GameObject> enemyList;
    private int playerDeathCount = 0;
    public bool isWin = false;
    public AudioManager audioManager;
    //public SceneManager BrightnessSetting;
    //public SliderJoint2D BrightnessSlider;
    public GameObject victory;
    public int nextScene;
    public float loseTimer;
    public TutorialAppear tutorial;
    public GameObject needGreedManager;
    public List<BattleSceneScriptableObject> waveDetails;


    public void Awake()
    {
        //audioManager.PlaySound("BattleSound");

        tutorial = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TutorialAppear>();
        playerList[0] = GameObject.FindGameObjectWithTag("Player1");
        playerList[1] = GameObject.FindGameObjectWithTag("Player2");
        AudioManager.instance.waveIndex++;

        Instantiate(waveDetails[AudioManager.instance.waveIndex].background, Vector3.zero,Quaternion.identity);
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

    }

    private void Update()
    {
        for (int i=enemyList.Count-1;i>=0;i--)
        {
            if(enemyList[i].GetComponent<EnemyStats>().health <= 0)
            {
                enemyList[i].SetActive(false);
                Destroy(enemyList[i]);
                enemyList.Remove(enemyList[i]);
                for(int j =0;j<playerList.Count;j++)
                {
                    playerList[j].GetComponent<PlayerVariableManager>().isTargetLockedIn = false;
                }

                this.GetComponent<ArtifactScript>().calArtifact();
            }

            
        }
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
                //UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
                needGreedManager.GetComponent<NeedGreedRandomizer>().addArtifactToPlayer();
            }
        }

        //! Test control to check the lose scene
        
        if (Input.GetKeyDown("b"))
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                playerList[i].GetComponent<PlayerStats>().health = 0;
                break;
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
