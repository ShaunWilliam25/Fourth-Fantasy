using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArtifactEffect : MonoBehaviour
{
    List<GameObject> artifacts;

    private void Awake()
    {
        artifacts = GetComponent<PlayerVariableManager>().artifactsList;
    }

    private void Update()
    {
        if (artifacts.Count > 0)
        {
            for (int i = 0; i < artifacts.Count; i++)
            {
                artifacts[i].GetComponent<ArtifactEffect>().carrier = gameObject;
                artifacts[i].GetComponent<ArtifactEffect>().Artifact();
            }
        }
    }

}
