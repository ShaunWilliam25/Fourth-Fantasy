
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArtifactEffect : MonoBehaviour
{
    List<GameObject> artifacts;
    public List<GameObject> artifactStatuses;

    private void Awake()
    {

    }

    private void Update()
    {
        artifacts = GetComponent<PlayerVariableManager>().artifactsList;
        if (artifacts.Count > 0)
        {
            for (int i = 0; i < artifacts.Count; i++)
            {
                artifacts[i].GetComponent<ArtifactEffect>().carrier = gameObject;
                artifacts[i].GetComponent<ArtifactEffect>().Artifact();
            }
        }
    }

    public void ArtifactActionEffect()
    {
        if(artifacts.Count>0)
        {
            for(int i=0;i<artifacts.Count;i++)
            {
                if(artifacts[i].GetComponent<ArtifactEffect>() is MagicalPendant && GetComponent<PlayerStats>().name == "OldGuard")
                {
                    GetComponent<PlayerTakeDamage>().PlayerHeal((int)(GetComponent<PlayerStats>().baseHealth * 0.02f));
                }
                if(artifacts[i].GetComponent<ArtifactEffect>() is TailOfSuccubus)
                {
                    for(int j=GetComponent<PlayerVariableManager>().statusList.Count-1;j>=0;j--)
                    {
                        if(GetComponent<PlayerVariableManager>().statusList[j].GetComponent<StatusDetail>().type == "Bad")
                        {
                            GetComponent<PlayerVariableManager>().statusList[j].GetComponent<StatusDetail>().RemoveStatus();
                            Destroy(GetComponent<PlayerVariableManager>().statusList[j].gameObject);
                            GetComponent<PlayerVariableManager>().statusList.Remove(GetComponent<PlayerVariableManager>().statusList[j]);
                            break;
                        }
                    }
                }
            }
        }
    }

    public void ArtifactAttackEffect(GameObject target)
    {
        if (artifacts.Count > 0)
        {
            for (int i = 0; i < artifacts.Count; i++)
            {
                if (!target.GetComponent<EnemyStats>().immune)
                {
                    if (artifacts[i].GetComponent<ArtifactEffect>() is FrozenFlame)
                    {
                        if (Random.Range(1, 3) == 1)
                        {
                            target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[0]));
                        }
                        else if (Random.Range(1, 3) == 2)
                        {
                            target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[1]));
                        }
                    }
                    if (artifacts[i].GetComponent<ArtifactEffect>() is BurningMark)
                    {
                        if(Random.Range(0,101) <=70)
                        {
                            target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[0]));
                        } 
                    }
                    if (artifacts[i].GetComponent<ArtifactEffect>() is SlowMark)
                    {
                        if (Random.Range(0, 101) <= 70)
                        {
                            target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[1]));
                        }
                    }
                    if (artifacts[i].GetComponent<ArtifactEffect>() is PoisonMark)
                    {
                        if (Random.Range(0, 101) <= 70)
                        {
                            target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[2]));
                        }
                    }
                    if (artifacts[i].GetComponent<ArtifactEffect>() is MarkOfTheRage)
                    {
                        if (Random.Range(0, 101) <= 70)
                        {
                            target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[3]));
                        }
                    }
                    if (artifacts[i].GetComponent<ArtifactEffect>() is ConfusingMark)
                    {
                        if (Random.Range(0, 101) <= 70)
                        {
                            target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[4]));
                        }
                    }
                    if(artifacts[i].GetComponent<ArtifactEffect>() is RingOfTheCursed)
                    {
                        if (Random.Range(0, 101) <= 10)
                        {
                            target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[5]));
                        }
                    }
                }
            }
        }
    }
}


