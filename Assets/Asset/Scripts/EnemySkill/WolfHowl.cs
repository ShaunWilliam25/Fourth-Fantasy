using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHowl : SkillEffect
{
    public GameObject wolfPrefab;
    private SceneManager sceneManager;
    private Enemy_Spawn enemySpawn;
    public int spawnCount;
    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        if(spawnCount<=0)
        {
            return;
        }
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        enemySpawn = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Enemy_Spawn>();
        //Summon Wolf
        if(enemyList.Count<3)
        {
            for(int i =0;i<enemySpawn.enemySpawnPoints.Count;i++)
            {
                if(enemySpawn.enemySpawnPoints[i].childCount<=0)
                {
                    GameObject wolfClone = Instantiate(wolfPrefab, new Vector2(enemySpawn.enemySpawnPoints[i].position.x, enemySpawn.enemySpawnPoints[i].position.y), Quaternion.identity, enemySpawn.enemySpawnPoints[i]);
                    sceneManager.enemyList.Insert(i,wolfClone);
                    sceneManager.enemyList[i].GetComponent<EnemyStats>().index = 1;
                    for(int j=0;j<wolfClone.GetComponent<EnemyVariableManager>().skillsPrefab.Count;j++)
                    {
                        wolfClone.GetComponent<EnemyVariableManager>().skillList.Add(Instantiate(wolfClone.GetComponent<EnemyVariableManager>().skillsPrefab[j],wolfClone.transform));
                    }
                    sceneManager.playerList[0].GetComponent<PlayerVariableManager>().isTargetLockedIn = false;
                    sceneManager.playerList[1].GetComponent<PlayerVariableManager>().isTargetLockedIn = false;
                    spawnCount--;
                    return;
                }
            }
        }
    }
}
