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

    public void returnBoolFalse()
    {
        this.GetComponent<needGreedShowUI>().greed1 = false;
        this.GetComponent<needGreedShowUI>().need1 = false;
        this.GetComponent<needGreedShowUI>().greed2 = false;
        this.GetComponent<needGreedShowUI>().need2 = false;
        this.GetComponent<needGreedShowUI>().selected1 = false;
        this.GetComponent<needGreedShowUI>().selected2 = false;
        Debug.Log("return");
        //canvas.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        randNum = Random.Range(1, 101);
        Player1OwnerText.SetActive(false);
        Player2OwnerText.SetActive(false);
        artifactAdded = false;
    }

    private void Awake()
    {
        playerList = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>().playerList;
        //canvas = GameObject.FindGameObjectWithTag("needGreedCanvas");
        ArtifactSpawner = artifactSpawnerSingleton.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<needGreedShowUI>().selected1 && this.GetComponent<needGreedShowUI>().selected2 && !artifactAdded)
        {
            Debug.Log("selected");

            if (this.GetComponent<needGreedShowUI>().greed1 && this.GetComponent<needGreedShowUI>().greed2)
            {
                Debug.Log("greed");
                if (randNum <= 50)
                {
                    owner = playerList[0];

                    addArtifact();
                    //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0].SetActive(false);
                    //owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);
                    //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);

                    Player1OwnerText.SetActive(true);
                    artifactAdded = true;
                }
                else if (randNum >= 51)
                {
                    owner = playerList[1];

                    addArtifact();
                    //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0].SetActive(false);
                    //owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);
                    //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);

                    Player2OwnerText.SetActive(true);
                    artifactAdded = true;
                }
                returnBoolFalse();
            }
            if (this.GetComponent<needGreedShowUI>().need1 && this.GetComponent<needGreedShowUI>().need2)
            {
                Debug.Log("need");
                if (randNum <= 50)
                {
                    owner = playerList[0];

                    addArtifact();
                    //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0].SetActive(false);
                    //owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);
                    //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);

                    Player1OwnerText.SetActive(true);
                    artifactAdded = true;
                }
                else if (randNum >= 51)
                {
                    owner = playerList[1];

                    addArtifact();
                    //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0].SetActive(false);
                    //owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);
                    //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);

                    Player2OwnerText.SetActive(true);
                    artifactAdded = true;
                }
                returnBoolFalse();
            }
            if (this.GetComponent<needGreedShowUI>().greed1 && this.GetComponent<needGreedShowUI>().need2)
            {
                Debug.Log("need2");
                owner = playerList[1];
                returnBoolFalse();

                addArtifact();
                //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0].SetActive(false);
                //owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);
                //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);

                Player2OwnerText.SetActive(true);
                artifactAdded = true;
            }
            if (this.GetComponent<needGreedShowUI>().need1 && this.GetComponent<needGreedShowUI>().greed2)
            {
                Debug.Log("need1");
                owner = playerList[0];
                returnBoolFalse();

                addArtifact();
                //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0].SetActive(false);
                //owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);
                //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);

                Player1OwnerText.SetActive(true);
                artifactAdded = true;
            }
            Debug.Log(owner);
            //Debug.Log(artifactAdded);
        }

        nameText.text = ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList[0].GetComponent<ArtifactInformation>().name;
        descText.text = ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList[0].GetComponent<ArtifactInformation>().effect;

    }

    public void addArtifactToPlayer()
    {
        Debug.Log("addtoarti");
        if (ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList.Count > 0)
        {
            canvas.SetActive(true);
            playerList[0].SetActive(false);
            playerList[1].SetActive(false);

            scenemanager.GetComponent<SceneManager>().VictoryGO.SetActive(false);

            ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList[0].SetActive(true);

            descriptionGO.SetActive(true);

            /*for(int i = 0; i < scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count; i++)
            {
                scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[i].SetActive(true);
                Debug.Log("seting is true and i = " + i);
            }*/

            if (artifactAdded)
            {
                Debug.Log("isartiaddedd = " + artifactAdded);
                if (Input.anyKeyDown)
                {
                    Debug.Log("C pressed");

                    this.GetComponent<needGreedShowUI>().p1State = needGreedShowUI.CAMPSITE_STATE.SELECTION;
                    this.GetComponent<needGreedShowUI>().p2State = needGreedShowUI.CAMPSITE_STATE.SELECTION;
                    artifactAdded = false;
                    returnBoolFalse();
                    owner = null;
                    Player1OwnerText.SetActive(false);
                    Player2OwnerText.SetActive(false);

                    ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList[0].SetActive(true);

                    descriptionGO.SetActive(true);

                    //if (scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count > 0)
                    //{

                    //}

                }
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                canvas.SetActive(false);
                Instantiate(scenemanager.GetComponent<SceneManager>().victory);
                if(Input.anyKeyDown)
                {
                    for(int i=0;i<scenemanager.GetComponent<SceneManager>().playerList.Count;i++)
                    {
                        scenemanager.GetComponent<SceneManager>().playerList[i].gameObject.SetActive(true);
                    }
                    
                    UnityEngine.SceneManagement.SceneManager.LoadScene(7);
                }                
                /*if(miniBoss)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(campsiteInt);
                    miniBoss = false;
                }
                else
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneInt);
                }*/
            }
        }
        /*/
        
        /*       for (int i = scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count - 1; i >= 0; i--)
               {
                   Debug.Log("inside for loop");
                   canvas.SetActive(true);
                   if (artifactAdded)
                   {
                       owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[i]);
                       //scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[i]);
                       artifactAdded = false;
                       canvas.SetActive(false);
                       //this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.SELECTION;
                       //this.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.SELECTION;

                   }
                   Debug.Log(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count);
               }
       */
        /*Debug.Log("addartifacttoplayer");
            owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[i]);
        scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[i]);
        artifactAdded = false;*/
    }

    public void addArtifact()
    {/*
        scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count - 1].SetActive(false);
        owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count - 1]);
        scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count - 1].transform.SetParent(owner.transform);
        scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count - 1]);
        */
        ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList[0].SetActive(false);
        owner.GetComponent<PlayerVariableManager>().artifactsList.Add(ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList[0]);
        ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList[0].transform.SetParent(owner.transform);
        ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList.Remove(ArtifactSpawner.GetComponent<ArtifactScript>().createdArtifactList[0]);

        descriptionGO.SetActive(false);

    }

}
/*
Debug.Log("Number of artifact is " + this.GetComponent<ArtifactScript>().ownedArtifactList.Count);
            do
            {
    Debug.Log("dowhileloop");
    canvas.SetActive(true);
    if (eventSys.GetComponent<NeedGreedRandomizer>().artifactAdded)
    {
        Debug.Log("ifadded");
        eventSys.GetComponent<NeedGreedRandomizer>().addArtifactToPlayer();
    }
    canvas.SetActive(false);

} while(this.GetComponent<ArtifactScript>().ownedArtifactList.Count > 0);
*/
