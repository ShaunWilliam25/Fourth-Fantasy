using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artifactSpawnerSingleton : MonoBehaviour {

    public static artifactSpawnerSingleton instance;

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

    public static artifactSpawnerSingleton Instance
    {
        get
        {
            return instance;
        }

    }
}
