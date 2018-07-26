using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void returnBoolFalse()
    {
        this.GetComponent<ShowUI>().greed1 = false;
        this.GetComponent<ShowUI>().need1 = false;
        this.GetComponent<ShowUI>().greed2 = false;
        this.GetComponent<ShowUI>().need2 = false;
        this.GetComponent<ShowUI>().selected1 = false;
        this.GetComponent<ShowUI>().selected2 = false;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<ShowUI>().selected1 && this.GetComponent<ShowUI>().selected2 && !artifactAdded)
        {
            Debug.Log("selected");

            if (this.GetComponent<ShowUI>().greed1 && this.GetComponent<ShowUI>().greed2)
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
            if (this.GetComponent<ShowUI>().need1 && this.GetComponent<ShowUI>().need2)
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
            if (this.GetComponent<ShowUI>().greed1 && this.GetComponent<ShowUI>().need2)
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
            if (this.GetComponent<ShowUI>().need1 && this.GetComponent<ShowUI>().greed2)
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
    }

    public void addArtifactToPlayer()
    {
        Debug.Log("addtoarti");
        if (scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count > 0)
        {
            canvas.SetActive(true);
            playerList[0].SetActive(false);
            playerList[1].SetActive(false);

            for(int i = 0; i < scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count; i++)
            {
                scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[i].SetActive(true);
                Debug.Log("seting is true and i = " + i);
            }

            if (artifactAdded)
            {
                Debug.Log("isartiaddedd = " + artifactAdded);
                if (Input.anyKeyDown)
                {Debug.Log("C pressed");
                        this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.SELECTION;
                        this.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.SELECTION;
                        artifactAdded = false;
                        returnBoolFalse();
                        owner = null;
                    Player1OwnerText.SetActive(false);
                    Player2OwnerText.SetActive(false);
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
    {
        scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count - 1].SetActive(false);
        owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count - 1]);
        scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Count - 1]);
        /*
        scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0].SetActive(false);
        owner.GetComponent<PlayerVariableManager>().artifactsList.Add(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);
        scenemanager.GetComponent<ArtifactScript>().ownedArtifactList.Remove(scenemanager.GetComponent<ArtifactScript>().ownedArtifactList[0]);
        */
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
