using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawn : MonoBehaviour {

    public List<int> characterIndex = new List<int>(2);
    [SerializeField] List<PlayerScriptableObject> characterList;
    public SceneManager sceneManager;
    public List<GameObject> allCharactersList;
    public List<GameObject> allSkillList;
    public float skillOffset;
    [SerializeField] private float skillPosOffset;

    private void Awake()
    {
        for(int i=0;i<characterIndex.Count;i++)
        {
            switch (characterIndex[i])
            {
                case 1:
                    sceneManager.playerList[i].GetComponent<PlayerStats>().baseHealth = characterList[0].maxHealth;
                    sceneManager.playerList[i].GetComponent<PlayerStats>().health = characterList[0].health;
                    sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = characterList[0].sprite;
                    sceneManager.playerList[i].transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = characterList[0].animator;
                    sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList = characterList[0].skillList;
                    sceneManager.playerList[i].transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(characterList[0].scale, characterList[0].scale, characterList[0].scale);
                    break;
                case 2:
                    sceneManager.playerList[i].GetComponent<PlayerStats>().baseHealth = characterList[1].maxHealth;
                    sceneManager.playerList[i].GetComponent<PlayerStats>().health = characterList[1].health;
                    sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = characterList[1].sprite;
                    sceneManager.playerList[i].transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = characterList[1].animator;
                    sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList = characterList[1].skillList;
                    sceneManager.playerList[i].transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(characterList[1].scale, characterList[1].scale, characterList[1].scale);
                    break;
            }
        }

        //! For each player
        for(int i=0;i<sceneManager.playerList.Count;i++)
        {
            //! Loop to instantiate skills
            for(int j=0;j<sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList.Count;j++)
            { 
                sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillHolder.Add(Instantiate(sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList[j], new Vector2((sceneManager.playerList[i].transform.GetChild(1).position.x + (skillOffset * j)*0.6f) - skillPosOffset, sceneManager.playerList[i].transform.GetChild(1).position.y), Quaternion.identity, sceneManager.playerList[i].transform.GetChild(1)));
            }
        }
    }

    void Start()
    {

    }
}
