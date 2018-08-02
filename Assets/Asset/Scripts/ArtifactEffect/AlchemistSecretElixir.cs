using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemistSecretElixir : ArtifactEffect {

    [SerializeField]List<GameObject> goodStatuses;
    public void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public override void Artifact()
    {
        if (!isEffect)
        {
            int rand = Random.Range(0, goodStatuses.Count + 1);
            carrier.GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(goodStatuses[rand]));
            isEffect = true;
        }
    }
}
