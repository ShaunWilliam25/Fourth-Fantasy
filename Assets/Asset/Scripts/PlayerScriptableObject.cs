using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewPlayer",menuName = "PLAYER")]
public class PlayerScriptableObject : ScriptableObject {
    public new string name;
    public Sprite sprite;
    public RuntimeAnimatorController animator;
    public int maxHealth;
    public int health;
    public List<GameObject> skillList;
    public float scale;
    public string idleAnimation;
    public string attackAnimation;
    public List<Sprite> skillImages;
    public List<string> skillNames;
    [TextArea]
    public List<string> skillDescriptions; 

}
