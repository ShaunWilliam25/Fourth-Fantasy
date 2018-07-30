using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBattleScene", menuName = "BATTLESCENE")]
[System.Serializable]
public class BattleSceneScriptableObject : ScriptableObject {
    //! the backkground which include the fire one
    public GameObject background;

    //! Enemies
    public List<int> enemiesToSpawn;
}
