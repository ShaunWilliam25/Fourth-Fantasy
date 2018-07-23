using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSound : MonoBehaviour
{
    void Start()
    {

    }

    public static BGSound instance = null;
    public static BGSound Instance
    {
        get { return instance; }
        //return to soundtrack
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
