using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStats : MonoBehaviour {

    public float health;
    public float baseHealth;
    [HideInInspector]public bool immune = false;
    [HideInInspector] public bool silence = false;
    [HideInInspector] public bool berserk = false;
    public new string name;
}
