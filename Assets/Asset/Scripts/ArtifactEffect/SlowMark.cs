using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMark : ArtifactEffect {

    public void Awake()
    {
        this.gameObject.SetActive(false);
    }
}
