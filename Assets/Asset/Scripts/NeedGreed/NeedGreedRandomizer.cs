using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedGreedRandomizer : MonoBehaviour
{

    public int randNum;
    public GameObject owner;
    public List<GameObject> playerList;
    public GameObject Player1OwnerText;
    public GameObject Player2OwnerText;
    public GameObject scenemanager;
    public bool artifactAdded;
    public GameObject canvas;
    public bool miniBoss;
    public int campsiteInt;
    public int nextSceneInt;
    public GameObject descriptionGO;
    public Text nameText;
    public Text descText;

    public GameObject ArtifactSpawner;
    public NeedGreedSelection needGreedSelection;
    public needGreedShowUI NeedGreedShowUI;

    public GameObject SpawnedArtifact;
    public int SpawnedArtifactCount;

    [SerializeField] TutorialAppear tutorial;

    private void Awake()
    {
        playerList = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>().playerList;
        ArtifactSpawner = artifactSpawnerSingleton.instance.gameObject;

        NeedGreedShowUI = GetComponent<needGreedShowUI>();
        needGreedSelection = GetComponent<NeedGreedSelection>();
        SpawnedArtifact = ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList[0];
        SpawnedArtifactCount = ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList.Count;

        needGreedSelection.enabled = false;
    }

    void Start()
    {
        randNum = Random.Range(1, 101);
        Player1OwnerText.SetActive(false);
        Player2OwnerText.SetActive(false);
        artifactAdded = false;
    }

    void Update()
    {
        if (NeedGreedShowUI.selected1 && NeedGreedShowUI.selected2 && !artifactAdded)
        {

            if (NeedGreedShowUI.greed1 && NeedGreedShowUI.greed2)
            {
                if (randNum <= 50)
                {
                    owner = playerList[0];

                    addArtifact();
                    

                    Player1OwnerText.SetActive(true);
                    artifactAdded = true;
                }
                else if (randNum >= 51)
                {
                    owner = playerList[1];

                    addArtifact();
                    

                    Player2OwnerText.SetActive(true);
                    artifactAdded = true;
                }
                returnBoolFalse();
            }
            if (NeedGreedShowUI.need1 && NeedGreedShowUI.need2)
            {
                if (randNum <= 50)
                {
                    owner = playerList[0];

                    addArtifact();
                    

                    Player1OwnerText.SetActive(true);
                    artifactAdded = true;
                }
                else if (randNum >= 51)
                {
                    owner = playerList[1];

                    addArtifact();
                    

                    Player2OwnerText.SetActive(true);
                    artifactAdded = true;
                }
                returnBoolFalse();
            }
            if (NeedGreedShowUI.greed1 && NeedGreedShowUI.need2)
            {
                owner = playerList[1];
                returnBoolFalse();

                addArtifact();
                

                Player2OwnerText.SetActive(true);
                artifactAdded = true;
            }
            if (NeedGreedShowUI.need1 && NeedGreedShowUI.greed2)
            {
                owner = playerList[0];
                returnBoolFalse();

                addArtifact();
                

                Player1OwnerText.SetActive(true);
                artifactAdded = true;
            }
        }
        if (SpawnedArtifactCount > 0)
        {
            nameText.text = SpawnedArtifact.GetComponent<ArtifactInformation>().name;
            descText.text = SpawnedArtifact.GetComponent<ArtifactInformation>().effect;
        }
    }

    public void addArtifactToPlayer()
    {
        if (SpawnedArtifactCount > 0)
        {
            canvas.SetActive(true);
            needGreedSelection.enabled = true;
            playerList[0].SetActive(false);
            playerList[1].SetActive(false);

            scenemanager.GetComponent<SceneManager>().VictoryGO.SetActive(false);

            SpawnedArtifact.SetActive(true);

            descriptionGO.SetActive(true);

            if (artifactAdded)
            {
                if (Input.anyKeyDown)
                {
                    NeedGreedShowUI.p1State = needGreedShowUI.CAMPSITE_STATE.SELECTION;
                    NeedGreedShowUI.p2State = needGreedShowUI.CAMPSITE_STATE.SELECTION;
                    artifactAdded = false;
                    returnBoolFalse();
                    owner = null;
                    Player1OwnerText.SetActive(false);
                    Player2OwnerText.SetActive(false);

                    SpawnedArtifact.SetActive(true);

                    descriptionGO.SetActive(true);
                }
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                canvas.SetActive(false);
                needGreedSelection.enabled = false;
                Instantiate(scenemanager.GetComponent<SceneManager>().victory);
                if(Input.anyKeyDown)
                {
                    for(int i=0;i<scenemanager.GetComponent<SceneManager>().playerList.Count;i++)
                    {
                        scenemanager.GetComponent<SceneManager>().playerList[i].gameObject.SetActive(true);
                    }
                    
                    //! Changing the tutorial
                    if(AudioManager.instance.isTutorial)
                    {
                        tutorial.tutorialStage = TutorialAppear.TUTORIAL_STAGE.STAGE_08;
                        tutorial.isLectureDone = false;
                    }
                    else
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadScene(7);
                    }
                }                
            }
        }
    }

    public void addArtifact()
    {
        SpawnedArtifact.SetActive(false);
        owner.GetComponent<PlayerVariableManager>().artifactsList.Add(SpawnedArtifact);
        SpawnedArtifact.transform.SetParent(owner.transform);
        ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList.Remove(SpawnedArtifact);

        descriptionGO.SetActive(false);

    }

    public void returnBoolFalse()
    {
        NeedGreedShowUI.greed1 = false;
        NeedGreedShowUI.need1 = false;
        NeedGreedShowUI.greed2 = false;
        NeedGreedShowUI.need2 = false;
        NeedGreedShowUI.selected1 = false;
        NeedGreedShowUI.selected2 = false;
    }

}