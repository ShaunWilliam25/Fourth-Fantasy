using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RestartBattle : MonoBehaviour
{

    public void RestartBattleScene (int RestartScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(RestartScene);
        
    }
   
}
