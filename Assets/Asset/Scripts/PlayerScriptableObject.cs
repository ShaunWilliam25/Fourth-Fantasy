using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer",menuName = "PLAYER")]
public class PlayerScriptableObject : ScriptableObject {
    public new string name;
    public Sprite sprite;
    public RuntimeAnimatorController animator;
    public int maxHealth;
    public int health;
    public List<GameObject> skillList;
    public float scale;

}
