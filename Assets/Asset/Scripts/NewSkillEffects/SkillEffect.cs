using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillEffect : MonoBehaviour {

    public List<GameObject> playerList;
    public List<GameObject> enemyList;
    public List<GameObject> status;
    public PlayerArtifactEffect playerArtifact;
    public GameObject user;
    public string effectDescription;
    public SKILL_EFFECT_TYPE effectType;
    public int damage;
    public int numOfTarget;
    public int upgradedTimes;
    public enum SKILL_EFFECT_TYPE
    {
        OFFENSIVE = 0,
        SUPPORTIVE,
        DEBUFF,
        HEAL
    }
    public AudioManager audioManager;

    public virtual void Execute(GameObject targetedEnemy)
    {

    }

    protected void AssignUser()
    {
        playerList = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().playerList;
        enemyList = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().enemyList;
        user = transform.parent.parent.parent.gameObject;
        playerArtifact = user.GetComponent<PlayerArtifactEffect>();
    }

    protected void AssignEnemyUser()
    {
        playerList = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().playerList;
        enemyList = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().enemyList;
    }

    protected float DamageAddOn()
    {
        List<GameObject> artifacts = user.GetComponent<PlayerVariableManager>().artifactsList;
        if (artifacts.Count > 0 && user.GetComponent<PlayerStats>().name == "OldGuard")
        {
            for (int i = 0; i < artifacts.Count; i++)
            {
                if (artifacts[i].GetComponent<ArtifactEffect>() is Masamune)
                {
                    return 100f;
                }
            }   
        }
        return 0;
    }

    protected float DamageMultiplier()
    {
        float multiplier = 1f;
        if(user.GetComponent<PlayerVariableManager>() != null)
        {
            if (user.GetComponent<PlayerVariableManager>().statusList.Count != 0)
            {
                for (int i = user.GetComponent<PlayerVariableManager>().statusList.Count - 1; i >= 0; i--)
                {
                    if (user.GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>() is Berserk)
                    {
                        multiplier *= 1.5f;
                    }
                    if (user.GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>() is Blessed)
                    {
                        multiplier *= 2f;
                    }
                    if (user.GetComponent<PlayerVariableManager>().statusList[i].GetComponent<StatusDetail>() is Cursed)
                    {
                        multiplier *= 0.5f;
                    }
                }
            }
        }
        else
        {
            if (user.GetComponent<EnemyVariableManager>().statusList.Count != 0)
            {
                for (int i = user.GetComponent<EnemyVariableManager>().statusList.Count - 1; i >= 0; i--)
                {
                    if (user.GetComponent<EnemyVariableManager>().statusList[i].GetComponent<StatusDetail>() is Berserk)
                    {
                        multiplier *= 1.5f;
                    }
                    if (user.GetComponent<EnemyVariableManager>().statusList[i].GetComponent<StatusDetail>() is Blessed)
                    {
                        multiplier *= 2f;
                    }
                    if (user.GetComponent<EnemyVariableManager>().statusList[i].GetComponent<StatusDetail>() is Cursed)
                    {
                        multiplier *= 0.5f;
                    }
                }
            }
        }
        return multiplier;
    }

}
