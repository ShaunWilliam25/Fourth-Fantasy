using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintShoes : ArtifactEffect {

    [SerializeField] GameObject haste;

    public void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public override void Artifact()
    {
        if(!isEffect)
        {
            carrier.GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(haste));
            isEffect = true;
        }
    }
}
