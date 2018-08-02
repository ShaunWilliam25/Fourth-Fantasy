using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needGreedManager : MonoBehaviour {

    public static needGreedManager instance;

    private void Awake()
    {
        if (instance != null && instance != this.gameObject)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static needGreedManager Instance
    {
        get
        {
            return instance;
        }

    }
}
