using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStats : MonoBehaviour {

    public float strength;
    public float baseStrength;
    public float magic;
    public float baseMagic;
    public float spirit;
    public float baseSpirit;
    public float defense;
    public float baseDefense;
    public float criticalChance;
    public float baseCriticalChance;
    public int criticalDamage;
    public int baseCriticalDamage;
    public float accuracy;
    public float baseAccuracy;
    public List<float> statusResistance = new List<float>(5);
    public List<float> baseStatusResistance = new List<float>(5);
    public float health;
    public float baseHealth;
    public float speed;
    public float baseSpeed;
    public float evasion;
    public float baseEvasion;
    public float timeNeeded;
    public float actionTimer;
    public bool immune = false;
    public bool silence = false;
    public new string name;

    //public List<StatusEffect> statusEffectList;

    private void Start()
    {
        strength = baseStrength;
        magic = baseMagic;
        spirit = baseSpirit;
        defense = baseDefense;
        criticalChance = baseCriticalChance;
        criticalDamage = baseCriticalDamage;
        accuracy = baseAccuracy;
        statusResistance = baseStatusResistance;
        health = baseHealth;
        speed = baseSpeed;
        evasion = baseEvasion;
    }
}
