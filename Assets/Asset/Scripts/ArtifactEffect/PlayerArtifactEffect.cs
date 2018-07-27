
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
                        target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[0]));
                    }
                    if (artifacts[i].GetComponent<ArtifactEffect>() is SlowMark)
                    {
                        target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[1]));
                    }
                    if (artifacts[i].GetComponent<ArtifactEffect>() is PoisonMark)
                    {
                        target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[2]));
                    }
                    if (artifacts[i].GetComponent<ArtifactEffect>() is MarkOfTheRage)
                    {
                        target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[3]));
                    }
                    if (artifacts[i].GetComponent<ArtifactEffect>() is ConfusingMark)
                    {
                        target.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(artifactStatuses[4]));
                    }
                }
            }
        }
    }
}


