using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHowl : SkillEffect
{
    public GameObject wolfPrefab;
    private SceneManager sceneManager;
    private Enemy_Spawn enemySpawn;
    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        enemySpawn = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Enemy_Spawn>();
        //Summon Wolf
        if(enemyList.Count<3)
        {
            for(int i =0;i<enemySpawn.enemySpawnPoints.Count;i++)
            {
                if(enemySpawn.enemySpawnPoints[i].childCount<=0)
                {
                    sceneManager.enemyList.Insert(i,Instantiate(wolfPrefab, new Vector2(enemySpawn.enemySpawnPoints[i].position.x, enemySpawn.enemySpawnPoints[i].position.y), Quaternion.identity, enemySpawn.enemySpawnPoints[i]));
                    sceneManager.enemyList[i].GetComponent<EnemyStats>().index = 1;
                    sceneManager.playerList[0].GetComponent<PlayerVariableManager>().isTargetLockedIn = false;
                    sceneManager.playerList[1].GetComponent<PlayerVariableManager>().isTargetLockedIn = false;
                    return;
                }
            }
        }
    }
}
